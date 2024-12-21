using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Folio;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
    {
        Folio.Public.Const.Data.SystemType = Folio.Public.Enum.System.SystemType.Browser;
        return AppBuilder.Configure<App>();
    }
}