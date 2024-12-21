using Avalonia;
using Folio.Public.Const;
using Folio.Public.Langs;

namespace Folio.Public.Module.Init;

public class Init
{
    public static void AfterNewUiEntry()
    {
        Ui.HandlePlatformUi();
        LangHelper.Current.ChangedCulture("zh-Hans");
    }

    public static void BeforeNewUiEntry()
    {
        Config.CreateFolder();
    }
}