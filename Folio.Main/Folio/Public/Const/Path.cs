using System;
using System.IO;

namespace Folio.Public.Const;

public class IPath
{
    public static string UserDataRootPath { get; set; } =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DaiYu.Folio");
}