using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using Folio.ViewModels;

namespace Folio.Views;

public partial class MainWindow : Window
{
    public MainWindowModel ViewModel { get; } = new();
    public MainWindow(out MainView mainView)
    {
        InitializeComponent();
        mainView = View;
        DataContext = ViewModel;
        Loaded += (_, _) =>
        {
            WindowState = WindowState.Maximized;
            WindowState = WindowState.Normal;
            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
            ExtendClientAreaToDecorationsHint = true;
        };
        PropertyChanged += (_, e) =>
        {
            if (e.Property.Name == nameof(WindowState))
                switch (WindowState)
                {
                    case WindowState.Normal:
                        Root.Margin = new Thickness(0);
                        Root.CornerRadius = new CornerRadius(8);
                        break;
                    case WindowState.Maximized:
                        Root.Margin = new Thickness(10);
                        Root.CornerRadius = new CornerRadius(0);
                        break;
                }
        };
    }
}