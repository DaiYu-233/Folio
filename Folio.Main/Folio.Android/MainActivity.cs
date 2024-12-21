using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Avalonia.Controls.Shapes;
using Java.Security;
using Path = System.IO.Path;

namespace Folio.Android;

[Activity(
    Label = "Folio.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        Public.Const.Data.SystemType = Public.Enum.System.SystemType.Android;
        return base.CustomizeAppBuilder(builder)
            .WithInterFont();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        Context context = this;
        var externalFilesDir = context.GetExternalFilesDir(null)?.AbsolutePath;
        if (!string.IsNullOrWhiteSpace(externalFilesDir))
        {
            Public.Const.IPath.UserDataRootPath = Path.Combine(externalFilesDir, "DaiYu.Folio");
        }

        base.OnCreate(savedInstanceState);
    }
}