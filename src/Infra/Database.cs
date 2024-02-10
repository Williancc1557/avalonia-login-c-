using System.Collections.Generic;
using CustomizedErrors;
using UserAccount;

public class Database {
    private static Database? instance;
    private readonly List<User> users = [];

    public static Database CreateInstance() {
        instance ??= new Database();
        return instance;
    }

    public void SaveUser(User user) {
        Validators(user);
        users.Add(user);
    }

    private void Validators(User user) {
        if (!Validator.ValidateEmail(user.GetEmail()))
            throw new InvalidEmailError("Invalid email address");

        if (!Validator.ValidatePassword(user.GetPassword()))
            throw new InvalidPasswordError("Invalid password");

        if (!Validator.ValidateName(user.GetName()))
            throw new InvalidNameError("Invalid name");
    }

    public List<User> GetUsers() {
        return users;
    }
}