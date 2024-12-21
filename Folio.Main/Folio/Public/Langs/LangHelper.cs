using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Folio.Public.Langs;

public class LangHelper : INotifyPropertyChanged
{
    public static LangHelper Current { get; } = new();

    public MainLang Resources { get; } = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public void ChangedCulture(string name)
    {
        if (string.IsNullOrEmpty(name) || name == "Unset")
            MainLang.Culture = CultureInfo.GetCultureInfo("zh-Hans");
        else
            MainLang.Culture = CultureInfo.GetCultureInfo(name);
        RaisePropertyChanged(nameof(Resources));
    }

    // public static string GetText(string name, string culture = "")
    // {
    //     var setting = Const.Data.Setting;
    //     CultureInfo cultureInfo;
    //     if (culture == "")
    //     {
    //         if (setting.Language == "zh-CN" || setting.Language == null)
    //             cultureInfo = CultureInfo.GetCultureInfo("");
    //         else
    //             cultureInfo = CultureInfo.GetCultureInfo(setting.Language);
    //     }
    //     else
    //     {
    //         cultureInfo = CultureInfo.GetCultureInfo(culture);
    //     }
    //
    //     var res = MainLang.ResourceManager.GetObject(name, cultureInfo).ToString();
    //     if (res == null)
    //         return "Null";
    //     return res;
    // }
}