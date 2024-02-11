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
        string errorMessage = "";
        if (!Validator.ValidateEmail(user.Email)) {
            errorMessage = "email";
            ErrorStack.PushError(errorMessage);
        }
        if (!Validator.ValidateName(user.Surname)) {
            errorMessage = "name";
            ErrorStack.PushError(errorMessage);
        }
        if (!Validator.ValidateName(user.Name)) {
            errorMessage = "Isurname";
            ErrorStack.PushError(errorMessage);
        }

        if (!string.IsNullOrEmpty(errorMessage)) throw new InvalidParameterError(errorMessage);
    }

    public ObservableCollection<User> GetUsers() {
        return users;
    }
}