using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using pwGazWater.Data;

namespace WpfChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection connection;  // подключение для взаимодействия с хабом

        public MainWindow()
        {
            InitializeComponent();
            employeeList.ItemsSource = Mongo.FindAllEmployee(CurrentUser.currentUser.Login);
            // создаем подключение к хабу
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7003/chat")
                .Build();


            // регистрируем функцию Receive для получения данных
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    chatbox.Items.Insert(0, newMessage);
                });
            });
        }

        // обработчик нажатия на кнопку
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправка сообщения
                await connection.InvokeAsync("Send", userTextBox.Text, messageTextBox.Text);
            }
            catch (Exception ex)
            {
                chatbox.Items.Add(ex.Message);
            }
        }

        private async void employeeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var user = (User)employeeList.SelectedItem;
            try
            {
                // подключемся к хабу
                await connection.StartAsync();
                chatbox.Items.Add("Вы вошли в чат");
                sendBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                chatbox.Items.Add(ex.Message);
            }
        }
    }
}
