using System;
using System.IO;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Folio.Public.Classes;

namespace Folio.Public.Module.Page.Create;

public class Image
{
    public static void Parse(string file)
    {
        using Stream stream = File.OpenRead(file);
        IImage image = new Bitmap(stream);
        App.UiRoot.ViewModel.Pages.Add(new IPage(Path.GetFileName(file), new PageTemplate.Image(image),
            file, null, true));
    }
}