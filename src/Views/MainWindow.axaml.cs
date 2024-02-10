using System;
using Assignment3.ViewModels;
using Avalonia.Controls;
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
            string? passwordText = password.Text;

            bool existsAllFields = string.IsNullOrEmpty(nameText) || string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(passwordText);
            if (existsAllFields) return;

            User user = new(nameText!, emailText!, passwordText!);
            MainWindowViewModel.AddNewUser(user);

            successLabel.Text = $"Congratulations! You've successfully signed up. Welcome to our community {user.Name}";
            successLabel.IsVisible = true;
            errorLabel.IsVisible = false;
        } catch (InvalidNameError nameError) {
            HandleError("The name is not valid", nameError);
        } catch (InvalidEmailError emailError) {
            HandleError("The email address is not valid", emailError);
        } catch (InvalidPasswordError passwordError) {
            HandleError("The password is not valid", passwordError);
        }
    }

    private void HandleError(string errorMessage, Exception exception) {
        errorLabel.Text = errorMessage;
        errorLabel.IsVisible = true;
        successLabel.IsVisible = false;
        Console.WriteLine(exception.Message);
    }
}