using Avalonia.Controls;
using Folio.Public.Const;
using Folio.Public.Module.Util;

namespace Folio.Public.Module.Init;

public class Config
{
    public static void CreateFolder()
    {
        Disk.TryCreateFolder(IPath.UserDataRootPath);
    }
    public static void CreateConfigFile()
    {
        
    }
}