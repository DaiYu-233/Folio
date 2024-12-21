using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Extensions.Media;
using Avalonia.Markup.Xaml;
using Folio.Public.PageTemplate.ViewModels;

namespace Folio.Public.PageTemplate;

public partial class Video : UserControl
{
    public Video(string path)
    {
        InitializeComponent();
        Loaded += (_, _) =>
        {
            VideoView.Play(path);
        };
    }
}