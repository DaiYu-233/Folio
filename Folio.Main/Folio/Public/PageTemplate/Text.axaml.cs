using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;

namespace Folio.Public.PageTemplate;

public partial class Text : UserControl
{
    public Text(string text, string extension)
    {
        InitializeComponent();
        TextEditor.Text = text;
        try
        {
            var _registryOptions = new RegistryOptions(Application.Current!.ActualThemeVariant == ThemeVariant.Light
                ? ThemeName.LightPlus
                : ThemeName.DarkPlus);
            TextEditor!.TextArea.TextView.LinkTextForegroundBrush =
                new SolidColorBrush(Color.Parse("#0098ff"));
            TextEditor.TextArea.TextView.LinkTextUnderline = false;
            var _textMateInstallation = TextEditor.InstallTextMate(_registryOptions);
            _textMateInstallation.SetGrammar(
                _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(extension).Id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}