using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace Folio.Public.PageTemplate;

public partial class Image : UserControl
{
    public Image(IImage image)
    {
        InitializeComponent();
        Viewer.Source = image;
        Loaded += (_, _) =>
        {
            Viewer.TranslateY = 0;
            Viewer.TranslateX = 0;
            Viewer.Scale = 0.6;
        };
    }
}