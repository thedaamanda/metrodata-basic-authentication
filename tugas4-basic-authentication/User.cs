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

        // method untuk menampilkan informasi user
        public string DisplayUser()
        {
            return $"Fullname\t: {this.FirstName} {this.LastName} \n" +
                    $"Username\t: {this.Username} \n" +
                    $"Password\t: {this.Password}";
        }
    }
}

