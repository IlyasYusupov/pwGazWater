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
        User receiver;
        HubConnection connection;  // подключение для взаимодействия с хабом
        public MainWindow()
        {
            InitializeComponent();
            employeeList.ItemsSource = Mongo.FindAllEmployee(CurrentUser.currentUser.Login);
            // создаем подключение к хабу
            
        }

        // обработчик нажатия на кнопку
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // отправка сообщения
                await connection.InvokeAsync("Send", CurrentUser.currentUser.Login, messageTextBox.Text, receiver.Login);
            }
            catch (Exception ex)
            {
                chatbox.Items.Add(ex.Message);
            }
        }

        private async void employeeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            receiver = (User)employeeList.SelectedItem;
            await DisposeAsync();
            try
            {
                connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7003/chat")
                .Build();

                // регистрируем функцию Receive для получения данных
                connection.On<string, string, string>("ReceiveMessage", (user, message, receive) =>
                {
                    var newMessage = $"{user}: {message}";
                    if ((user == receiver.Login && receive == CurrentUser.currentUser.Login) || (user == CurrentUser.currentUser.Login && receive == receiver.Login))
                    {
                        Dispatcher.Invoke(() =>
                        {
                            chatbox.Items.Insert(0, newMessage);
                        });
                    }

                });
                // подключемся к хабу
                await connection.StartAsync();
                chatbox.Items.Clear();
                chatWith.Content = $"Вы вошли в чат с {receiver.Login}";
                sendBtn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                chatbox.Items.Add(ex.Message);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (connection is not null)
            {
                await connection.DisposeAsync();
            }
        }
    }
}
