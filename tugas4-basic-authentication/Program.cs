namespace tugas4_basic_authentication
{
    class Program
    {
        static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                Console.WriteLine("== BASIC AUTHENTICATION ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");

                Console.Write("Input: ");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ReadUser();
                        break;
                    case "3":
                        SearchUser();
                        break;
                    case "4":
                        LoginUser();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again with another input.");
                        break;
                }
                Console.WriteLine();
            }
        }

        // method untuk mengecek apakah username sudah ada atau belum
        static bool ValidateUsername(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    return true;
                }
            }
            return false;
        }

        // method untuk mengecek apakah password sudah valid atau tidak
        static bool ValidatePassword(string password)
        {
            if (password.Length < 8 || !password.Any(char.IsLower) || !password.Any(char.IsUpper) || !password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        // method to check user authentication
        static User AuthenticateUser(string username, string password)
        {
            return users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        // method untuk membuat user
        static void CreateUser()
        {
            Console.Clear();
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            string username = (firstName).ToLower().Substring(0, 2) + (lastName).ToLower().Substring(0, 2);

            // cek apakah username sudah ada
            while (ValidateUsername(username))
            {
                Console.WriteLine(username);
                Console.WriteLine("Username already exist. Please try again with other First or Last Name.");

                Console.Write("First Name: ");
                firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                lastName = Console.ReadLine();

                username = (firstName).ToLower().Substring(0, 2) + (lastName).ToLower().Substring(0, 2);
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();

            // cek apakah password sudah valid
            while (ValidatePassword(password) == false)
            {
                Console.WriteLine("Password must have at least 8 characters with at least one Capital letter, at least one lower case letter and at least one number");

                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            User user = new User(firstName, lastName, password, username);
            users.Add(user);

            Console.WriteLine("\nData berhasil dibuat.");
            Console.ReadLine();
        }

        // method untuk menampilkan seluruh user
        static void ReadUser()
        {
            Console.Clear();
            Console.WriteLine("== SHOW USER ==");

            foreach (var (user, index) in users.Select((user, index) => (user, index)))
            {
                Console.WriteLine("======================");
                Console.WriteLine("ID\t\t: " + (index + 1));
                Console.WriteLine(user.DisplayUser());
                Console.WriteLine("======================");
            }

            Console.WriteLine("\nSelect an operation:");
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            string operationShow = Console.ReadLine();

            switch (operationShow)
            {
                case "1":
                    EditUser();
                    break;
                case "2":
                    DeleteUser();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please try again.");
                    break;
            }
        }

        // method untuk mencari user berdasarkan first name atau last name
        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("== CARI USER ==");
            Console.Write("Masukkan Nama: ");
            string name = Console.ReadLine();

            foreach (var (user, index) in users.Select((user, index) => (user, index)))
            {
                if (user.FirstName.ToLower().Contains(name.ToLower()) || user.LastName.ToLower().Contains(name.ToLower()))
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("ID\t\t: " + (index + 1));
                    Console.WriteLine(user.DisplayUser());
                    Console.WriteLine("======================");
                }
            }
            Console.ReadLine();
        }

        // method untuk login user
        static void LoginUser()
        {
            Console.Clear();
            Console.WriteLine("== LOGIN USER ==");
            Console.Write("Masukkan Username: ");
            string username = Console.ReadLine();

            Console.Write("Masukkan Password: ");
            string password = Console.ReadLine();

            var userLogin = AuthenticateUser(username, password);

            if(userLogin != null)
            {
                Console.WriteLine("Login Berhasil dengan Nama " + userLogin.GetFullName());
            }
            else
            {
                Console.WriteLine("Login Gagal");
            }

            Console.ReadLine();
        }

        // method untuk mengedit user
        static void EditUser()
        {
            Console.Write("ID Yang Ingin Diubah :");
            int index = int.Parse(Console.ReadLine());

            Console.Write("First Name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string newLastName = Console.ReadLine();

            Console.Write("Password: ");
            string newPassword = Console.ReadLine();

            // cek apakah password sudah valid
            while (ValidatePassword(newPassword) == false)
            {
                Console.WriteLine("Password must have at least 8 characters with at least one Capital letter, at least one lower case letter and at least one number");

                Console.Write("Password: ");
                newPassword = Console.ReadLine();
            }

            string newUsername = (newFirstName).ToLower().Substring(0, 2) + (newLastName).ToLower().Substring(0, 2);

            User newData = new User(newFirstName, newLastName, newPassword, newUsername);
            users[index - 1] = newData;

            Console.WriteLine("User Sudah Berhasil Di Edit");
            Console.ReadLine();
            ReadUser();
        }

        // method untuk menghapus user
        static void DeleteUser()
        {
            Console.Clear();

            Console.WriteLine("ID Yang Ingin Dihapus :");
            int index = int.Parse(Console.ReadLine());

            users.RemoveAt(index - 1);

            Console.WriteLine("Akun berhasil dihapus");
            Console.ReadLine();
            ReadUser();
        }
    }
}
