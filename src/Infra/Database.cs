using System.Collections.Generic;
using UserAccount;

public class Database {
    private static Database? instance;
    private List<User> users = new();


    public static Database CreateInstance() {
        instance ??= new Database();
        return instance;
    }

    private void SaveUser(User user) {
        users.Add(user);
    }
}