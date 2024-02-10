using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserAccount;

namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static ObservableCollection<User> Users { get; set;} = [];

    public static void AddNewUser(User user)
    {
        Database.CreateInstance().SaveUser(user);
        Users.Add(user);
    }
}
