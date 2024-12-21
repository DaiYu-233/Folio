using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using Folio.Public.Classes;
using Folio.Public.Module.Util;

namespace Folio.Public.Module.Page.Create;

public class Markdown
{
    public static async void Parse(string file)
    {
        await Task.Run(async () =>
        {
            try
            {
                var text = await File.ReadAllTextAsync(file);
                Dispatcher.UIThread.Invoke(() =>
                {
                    App.UiRoot.ViewModel.Pages.Add(new IPage(Path.GetFileName(file),
                        new PageTemplate.Markdown(text),
                        file, null, true));
                }, DispatcherPriority.ApplicationIdle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        });
    }
}