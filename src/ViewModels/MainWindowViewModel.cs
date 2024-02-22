using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using UserAccount;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;


namespace Assignment3.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static readonly MessageObserver messageObserver = new();
    public static ObservableCollection<User> Users { get; set;} = [];
    public static ObservableCollection<User> UsersBeforeUpdate { get; set;} = [];

    public static void AddNewUser(User user)
    {
        Database.CreateInstance().SaveUser(user);
        Users.Add(user);
        UsersBeforeUpdate.Add(user);
    }

    public static void FilterUser(string? textToFilter) {
        string textWithoutSpace = textToFilter!.Trim();
        if (IsNullOrEmptyText(textWithoutSpace)) return;
        CheckIfNotHaveUserToFilter();

        List<User> filteredUsers = Users.Where(obj => obj.Email.Contains(textWithoutSpace!)).ToList();

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

    public static void ExportData() {
        List<User> usersToExport = Database.CreateInstance().GetUsers();

        var json = JsonSerializer.Serialize(usersToExport);

        using var streamWriter = new StreamWriter("backups/backup.json");
        streamWriter.Write(json);
    }

    [System.Obsolete]
    public async static void ImportData(TopLevel topLevel) {
        var options = new FilePickerOpenOptions
        {
            FileTypeFilter = [FilePickerFileTypes.All],
            Title = "Selecionar arquivo JSON"
        };

        var file = await topLevel?.StorageProvider.OpenFilePickerAsync(options)!;
        await using var stream = await file[0].OpenReadAsync();
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();

        List<User>? users = JsonSerializer.Deserialize<List<User>>(content);

        if (users == null || users.Count == 0) {
            Subject subject = new();
            subject.Attach(messageObserver);
            subject.Notify("Invalid file");
            return;
        }


        foreach (User user in users) {
            Console.WriteLine(user.Name);
            Users.Add(user);
        }
    }

    public static void ImplementFilteredUsers(List<User> filteredUsers) {
        foreach (User user in filteredUsers) {
            Users.Add(user);
        }
    }
}
