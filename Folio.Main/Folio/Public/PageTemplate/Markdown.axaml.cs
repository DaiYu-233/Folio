using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaEdit.TextMate;
using Folio.Public.PageTemplate.ViewModels;
using TextMateSharp.Grammars;

namespace Folio.Public.PageTemplate;

public partial class Markdown : UserControl
{
    public Markdown(string markdown)
    {
        DataContext = new MarkdownViewModel();
        InitializeComponent();
        TextEditor.Text = markdown;
        MarkdownScrollViewer.Markdown = markdown;
        var _registryOptions = new RegistryOptions(Application.Current!.ActualThemeVariant == ThemeVariant.Light
            ? ThemeName.LightPlus
            : ThemeName.DarkPlus);
        TextEditor!.TextArea.TextView.LinkTextForegroundBrush =
            new SolidColorBrush(Color.Parse("#0098ff"));
        TextEditor.TextArea.TextView.LinkTextUnderline = false;
        var _textMateInstallation = TextEditor.InstallTextMate(_registryOptions);
        _textMateInstallation.SetGrammar(
            _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".md").Id));
    }
}