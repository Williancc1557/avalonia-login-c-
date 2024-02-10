using System.Collections.Generic;
using CustomizedErrors;
using UserAccount;

public class Database {
    private static Database? instance;
    private List<User> users = new();


    public static Database CreateInstance() {
        instance ??= new Database();
        return instance;
    }

    private void SaveUser(User user) {
        Validators(user);
        users.Add(user);
    }

    private void Validators(User user) {
        if (!Validator.ValidateEmail(user.GetEmail()))
            throw new InvalidEmailError("Invalid email address");

        if (!Validator.ValidatePassword(user.GetPassword()))
            throw new InvalidPasswordError("Invalid password");

        if (!Validator.ValidateName(user.GetEmail()))
            throw new InvalidNameError("Invalid name");
    }
}