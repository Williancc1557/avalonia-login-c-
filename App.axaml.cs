using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Assignment3.ViewModels;
using Assignment3.Views;

namespace Assignment3;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new FormWindow
            {
                DataContext = new FormWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}