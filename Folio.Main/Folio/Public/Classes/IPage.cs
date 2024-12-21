using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace Folio.Public.Classes;

public sealed class IPage : INotifyPropertyChanged
{
    private SolidColorBrush _bg;
    public string DisplayName { get; set; }
    public IImage? Icon { get; set; }
    public string Uuid { get; set; }
    public double ImageWidth { get; set; } = 20;
    public string Path { get; set; }
    public Thickness Margin { get; set; } = new(10, 0);
    public UserControl Page { get; set; }

    public SolidColorBrush Bg
    {
        get => _bg;
        set => SetField(ref _bg, value);
    }

    public IPage(string displayName, UserControl page, string path, IImage? icon = null, bool select = false, string? uuid = null)
    {
        DisplayName = displayName;
        Path = path;
        Page = page;
        if (icon != null) Icon = icon;
        else
        {
            ImageWidth = 0;
            Margin = new Thickness(5, 0, 10, 0);
        }

        Uuid = uuid ?? System.Guid.NewGuid().ToString();
        if (select)
        {
            if (App.UiRoot != null)
            {
                Application.Current!.Resources.TryGetResource("PageItemBg", Application.Current.ActualThemeVariant,
                    out var c1);
                foreach (var p in App.UiRoot.ViewModel.Pages)
                {
                    p.Bg = (SolidColorBrush)c1!;
                }
                App.UiRoot.ViewModel.SelectedPage = this;
            }

            Application.Current!.Resources.TryGetResource("SelectedPageItemBg", Application.Current.ActualThemeVariant,
                out var c);
            _bg = (SolidColorBrush)c!;
        }
        else
        {
            Application.Current!.Resources.TryGetResource("PageItemBg", Application.Current.ActualThemeVariant,
                out var c);
            _bg = (SolidColorBrush)c!;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        OnPropertyChanged(propertyName);
    }

    public void Select()
    {
        Application.Current!.Resources.TryGetResource("PageItemBg", Application.Current.ActualThemeVariant, out var n);
        Application.Current!.Resources.TryGetResource("SelectedPageItemBg", Application.Current.ActualThemeVariant,
            out var a);
        foreach (var page in App.UiRoot.ViewModel.Pages)
        {
            page.Bg = (SolidColorBrush)n!;
        }

        Bg = (SolidColorBrush)a!;
        App.UiRoot.ViewModel.SelectedPage = this;
    }
}