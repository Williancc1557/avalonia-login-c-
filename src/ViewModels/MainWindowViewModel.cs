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

    public async static void ExportData(TopLevel topLevel) {
        try {
            var options = new FolderPickerOpenOptions()
            {
                Title = "Selecionar pasta",
                AllowMultiple = false
            };
            var path = await topLevel.StorageProvider.OpenFolderPickerAsync(options);
            List<User> usersToExport = Database.CreateInstance().GetUsers();

            var json = JsonSerializer.Serialize(usersToExport);

            using var streamWriter = new StreamWriter($"{path[0].Path.AbsolutePath}/backup.json");
            streamWriter.Write(json);
        } catch (Exception err) {
            Console.WriteLine(err);
            Logger.Debug("export data failed");
        }
    }

    public async static void ImportData(TopLevel topLevel) {
        try {
            var options = new FilePickerOpenOptions
            {
                FileTypeFilter = [FilePickerFileTypes.All],
                Title = "Selecionar arquivo JSON",
                AllowMultiple = false
            };

            var file = await topLevel.StorageProvider.OpenFilePickerAsync(options);
            await using var stream = await file[0].OpenReadAsync();
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();

            List<User>? users = JsonSerializer.Deserialize<List<User>>(content) ?? throw new Exception();

            foreach (User user in users) {
                Users.Add(user);
                Database.CreateInstance().SaveUser(user);
            }
        } catch (ArgumentOutOfRangeException) {
            Logger.Debug("import data failed");
        }
    }

    public static void ImplementFilteredUsers(List<User> filteredUsers) {
        foreach (User user in filteredUsers) {
            Users.Add(user);
        }
    }
}
