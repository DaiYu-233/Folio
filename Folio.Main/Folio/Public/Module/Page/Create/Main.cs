using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Platform.Storage;

namespace Folio.Public.Module.Page.Create;

public class NewPage
{
    public static void CreateNewPage(IStorageFile storageFile)
    {
        var type = Path.GetExtension(storageFile.Name);
        string file;
        if (Const.Data.SystemType == Enum.System.SystemType.Android)
        {
            var match = Regex.Match(storageFile.Path.LocalPath, @"raw:/(.*)");
            if (match.Success)
            {
                file = match.Groups[1].Value;
            }
            else
            {
                return;
            }
        }
        else
        {
            file = storageFile.Path.LocalPath;
        }

        switch (type)
        {
            case ".png":
            case ".jpg":
            case ".jpeg":
            case ".gif":
            case ".bmp":
            case ".svg":
            case ".webp":
                Image.Parse(file);
                break;
            default:
                Text.Parse(file);
                break;
        }
    }
}