﻿using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using Folio.Public.Classes;

namespace Folio.Public.Module.Page.Create;

public class Image
{
    public static async void Parse(string file)
    {
        await Task.Run(() =>
        {
            try
            {
                using Stream stream = File.OpenRead(file);
                IImage image = new Bitmap(stream);
                Dispatcher.UIThread.Invoke(() =>
                {
                    App.UiRoot.ViewModel.Pages.Add(new IPage(Path.GetFileName(file), new PageTemplate.Image(image),
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