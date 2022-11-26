namespace pwGazWater.Data
{
    public class SingletonServise
    {
        private User user;

        public User GetUser()
        {
            return user;
        }

        public void SetUser(User user)
        {
            this.user = user;
        }
    }
}