using UserAccount;

namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static void AddNewUser(User user)
    {
        Database.CreateInstance().SaveUser(user);
    }
}
