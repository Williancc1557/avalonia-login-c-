using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserAccount;

namespace Assignment3.ViewModels;

public class FormWindowViewModel : ViewModelBase
{
    public ObservableCollection<UserForms> Users { get; }

    public FormWindowViewModel()
    {
        List<UserForms> users = new() {
            new UserForms("willzin@gmail", "willzin", "ilha12345") {}
        };
        foreach (User user in Database.CreateInstance().GetUsers()) {
            users.Add(new UserForms(user.GetName(), user.GetEmail(), user.GetPassword()));
        }

        Users = new ObservableCollection<UserForms>(users);
    }

}
