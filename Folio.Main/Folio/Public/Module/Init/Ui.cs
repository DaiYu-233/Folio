using Avalonia.Media;

namespace Folio.Public.Module.Init;

public class Ui
{
    public static void HandlePlatformUi()
    {
        if (Const.Data.SystemType != Enum.System.SystemType.Desktop)
        {
            Folio.App.UiRoot.TitleBar.IsVisible = false;
            Folio.App.UiRoot.Background = Brushes.Transparent;
        }
    }
}