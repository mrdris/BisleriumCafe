using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Provider;

public static class FilePath
{
    public static string GetAppDirectoryPath()
    {
        return Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Bislerium-Cafe"
        );
    }

    public static string GetAppUsersFilePath()
    {
        return Path.Combine(GetAppDirectoryPath(), "users.json");
    }

    public static string GetCoffeeFilePath(Guid userId)
    {
        return Path.Combine(GetAppDirectoryPath(), userId.ToString() + "_cafe.json");
    }
}
