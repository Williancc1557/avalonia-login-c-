public class UserForms {
    public string Name {set; get;}
    public string Email {set; get;}
    public string Password {set; get;}

    public UserForms(string name, string email, string password) {
        Name = name;
        Email = email;
        Password = password;
    }
}