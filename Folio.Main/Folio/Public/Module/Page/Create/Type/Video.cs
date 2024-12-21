using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Threading;
using Folio.Public.Classes;

namespace Folio.Public.Module.Page.Create;

public class Video
{
    public static async void Parse(string file)
    {
        await Task.Run(() =>
        {
            try
            {
                Dispatcher.UIThread.Invoke(() =>
                {
                    App.UiRoot.ViewModel.Pages.Add(new IPage(Path.GetFileName(file),
                        new PageTemplate.Video(file),
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