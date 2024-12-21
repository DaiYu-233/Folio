using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Folio.Public.PageTemplate;

public partial class Text : UserControl
{
    public Text(string text, string extension)
    {
        InitializeComponent();
        TextEditor.Text = text; 
        var _registryOptions = new RegistryOptions(ThemeName.LightPlus);
        var _textMateInstallation = TextEditor.InstallTextMate(_registryOptions);
        _textMateInstallation.SetGrammar(
            _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(extension).Id));
    }
}