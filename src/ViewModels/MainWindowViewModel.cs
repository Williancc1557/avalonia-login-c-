using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserAccount;

namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<UserForms> Users { get; }

    public MainWindowViewModel()
    {
        List<UserForms> users = new() {
            new UserForms("willzin@gmail", "willzin", "ilha12345") {}
        };
        foreach (User user in Database.CreateInstance().GetUsers()) {
            users.Add(new UserForms(user.GetName(), user.GetEmail(), user.GetPassword()));
        }

        Users = new ObservableCollection<UserForms>(users);
    }

    public static void AddNewUser(User user)
    {
        Database.CreateInstance().SaveUser(user);
    }
}
