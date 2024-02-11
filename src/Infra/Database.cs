using System.Collections.ObjectModel;
using CustomizedErrors;
using UserAccount;

public class Database {
    private static Database? instance;
    private readonly ObservableCollection<User> users = [];

    public static Database CreateInstance() {
        instance ??= new Database();
        return instance;
    }

    public void SaveUser(User user) {
        Validators(user);
        users.Add(user);
        MessageObserver messageObserver = new();
        Subject subject = new();
        subject.Attach(messageObserver);
        subject.Notify($"User {user.Email} has been added.");
    }

    private void Validators(User user) {
        if (!Validator.ValidateEmail(user.Email))
            throw new InvalidEmailError("Invalid email address");

        if (!Validator.ValidatePassword(user.Password))
            throw new InvalidPasswordError("Invalid password");

        if (!Validator.ValidateName(user.Password))
            throw new InvalidNameError("Invalid name");
    }

    public ObservableCollection<User> GetUsers() {
        return users;
    }
}