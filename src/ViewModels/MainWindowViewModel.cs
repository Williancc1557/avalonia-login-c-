using UserAccount;

namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static void AddNewUser(User user)
    {
        Validation(user);
        Save(user);
    }

    private static bool Validation(User user) {
        bool isValid = true;

        // Add validation

        return isValid;
    }

    private static void Save(User user) {
        System.Console.WriteLine($"LOGS: Save User {user.Email}");
        // connection with database
    }
}
