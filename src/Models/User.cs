using System.Text;

namespace UserAccount {
    public class User {
        public string Email {set; get;}
        public string Password {set; get;}
        public string Name {set; get;}


        public User(string name, string email, string password) {
            Email = email;
            Password = password;
            Name = name;
        }

        public string GetToString()
        {
            StringBuilder text = new();

            text.Append($"Email: {Email}");
            text.Append('\n');
            text.Append($"Password: {Password}");

            return text.ToString();
        }
    }
}