using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DynamicData;
using UserAccount;

namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public static ObservableCollection<User> Users { get; set;} = [];
    public static ObservableCollection<User> UsersBeforeUpdate { get; set;} = [];

    public static void AddNewUser(User user)
    {
        Database.CreateInstance().SaveUser(user);
        Users.Add(user);
        UsersBeforeUpdate.Add(user);
    }

    public static void FilterUser(string? textToFilter) {
        if (IsNullOrEmptyText(textToFilter)) return;
        CheckIfNotHaveUserToFilter();

        List<User> filteredUsers = Users.Where(obj => obj.Email.Contains(textToFilter!)).ToList();

        Users.Clear();
        ImplementFilteredUsers(filteredUsers);
    }

    public static bool IsNullOrEmptyText(string? text) {
        if (string.IsNullOrEmpty(text)) {
            Users.Clear();
            foreach (User user in UsersBeforeUpdate) {
                Users.Add(user);
            }

            return true;
        }

        return false;
    }

    public static void CheckIfNotHaveUserToFilter() {
        if (Users.Count == 0) {
            foreach (User user in UsersBeforeUpdate) {
                Users.Add(user);
            }
        }
    }

    public static void ImplementFilteredUsers(List<User> filteredUsers) {
        foreach (User user in filteredUsers) {
            Users.Add(user);
        }
    }
}
