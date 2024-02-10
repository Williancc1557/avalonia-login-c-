using Assignment3.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using UserAccount;

namespace Assignment3.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void GreetingButtonClickHandler(object sender, RoutedEventArgs e)
    {
        string? emailText = email.Text;
        string? passwordText = password.Text;

        if (string.IsNullOrEmpty(emailText) || string.IsNullOrEmpty(passwordText)) return;

        User user = new(emailText, passwordText);
        MainWindowViewModel.AddNewUser(user);

        successLabel.Text = $"Registrado com sucesso utilizando o email {user}";
        successLabel.IsVisible = true;
    }
}