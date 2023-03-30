namespace tugas4_basic_authentication
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public User(string firstName, string lastName, string password, string username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Username = username;
        }
    }
}

