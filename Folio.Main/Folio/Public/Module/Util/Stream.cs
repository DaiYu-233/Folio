using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Folio.Public.Module.Util;

public class Stream
{
    public static Bitmap LoadBitmapFromAppFile(string uri)
    {
        var memoryStream = new MemoryStream();
        var stream = AssetLoader.Open(new Uri("resm:" + uri));
        stream!.CopyTo(memoryStream);
        memoryStream.Position = 0;
        return new Bitmap(memoryStream);
    }
}