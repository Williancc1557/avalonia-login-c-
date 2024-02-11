using System.Text;

namespace UserAccount {
    public class User {
        public string Email {set; get;}
        public string Surname {set; get;}
        public string Name {set; get;}


        public User(string name, string email, string surname) {
            Email = email;
            Surname = surname;
            Name = name;
        }

        public string GetToString()
        {
            StringBuilder text = new();

            text.Append($"Email: {Email}");
            text.Append('\n');
            text.Append($"Surname: {Surname}");

            return text.ToString();
        }
    }
}