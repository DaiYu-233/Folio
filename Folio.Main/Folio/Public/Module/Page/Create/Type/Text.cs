using System.IO;
using Avalonia.Platform.Storage;
using Folio.Public.Classes;
using Folio.Public.PageTemplate;

namespace Folio.Public.Module.Page.Create;

public class Text
{
    public static void Parse(string file)
    {
        var text = File.ReadAllText(file);
        App.UiRoot.ViewModel.Pages.Add(new IPage(Path.GetFileName(file), new PageTemplate.Text(text, Path.GetExtension(file)),
            file, null, true));
    }
}