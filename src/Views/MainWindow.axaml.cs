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
            string? emailText = email.Text;
            string? passwordText = password.Text;

            if (string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(passwordText)) return;

            User user = new(emailText, passwordText);
            MainWindowViewModel.AddNewUser(user);

            successLabel.Text = $"Registrado com sucesso utilizando o email {user}";
            successLabel.IsVisible = true;
            errorLabel.IsVisible = false;
        } catch (InvalidEmailError emailError) {
            HandleError("The email address is not valid", emailError);
        } catch (InvalidPasswordError passwordError) {
            HandleError("The password is not valid", passwordError);
        } catch (InvalidNameError nameError) {
            HandleError("The name is not valid", nameError);
        }
    }

    private void HandleError(string errorMessage, Exception exception) {
        errorLabel.Text = errorMessage;
        errorLabel.IsVisible = true;
        Console.WriteLine(exception.Message);
    }
}