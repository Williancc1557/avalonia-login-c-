using System;
using Assignment3.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using CustomizedErrors;
using UserAccount;

namespace Assignment3.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Handle(object sender, RoutedEventArgs e)
    {
        try {
            string? nameText = name.Text;
            string? emailText = email.Text;
            string? surnameText = surname.Text;

            bool existsAllFields = string.IsNullOrEmpty(nameText) || string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(surnameText);
            if (existsAllFields) return;

            User user = new(nameText!, emailText!, surnameText!);
            MainWindowViewModel.AddNewUser(user);

            successLabel.Text = $"Congratulations! You've successfully signed up. Welcome to our community {user.Name}";
            successLabel.IsVisible = true;
            errorLabel.IsVisible = false;

            Clear();
        } catch (Exception nameError) {
            HandleError(ErrorStack.PopError(), nameError);
        }
    }

    public void ExportData(object sender, RoutedEventArgs e) {
        MainWindowViewModel.ExportData();
    }

    private void HandleError(string errorMessage, Exception exception) {
        errorLabel.Text = errorMessage;
        errorLabel.IsVisible = true;
        successLabel.IsVisible = false;
    }

    private void FilterTextUpdate(object sender, KeyEventArgs e) {
        MainWindowViewModel.FilterUser(filterByEmail.Text);
    }

    private void Clear() {
        name.Text = "";
        email.Text = "";
        surname.Text = "";
    }
}