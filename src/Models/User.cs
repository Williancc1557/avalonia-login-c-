using System.Text;

namespace UserAccount {
    public class User {
        private readonly string _email;
        private readonly string _password;
        private readonly string _name;

        public User(string name, string email, string password) {
            _email = email;
            _password = password;
            _name = name;
        }

        public string GetToString()
        {
            StringBuilder text = new();

            text.Append($"Email: {_email}");
            text.Append('\n');
            text.Append($"Password: {_password}");

            return text.ToString();
        }

        public string GetEmail() {
            return _email;
        }

        public string GetPassword() {
            return _password;
        }

        public string GetName() {
            return _name;
        }
    }
}