using System;
using System.Collections.Generic;
using System.IO;
using Entities.Enums;
using Entities.Files;
using Services.Core.FileManagers;

namespace Services.FileManagers;

public class FileManagerService : IFileManagerService
{
    public IEnumerable<FileModel> GetFolderData(string path)
    {
        if (!Directory.Exists(path))
            yield break;

        string[] folders, files;

        try
        {
            folders = Directory.GetDirectories(path);
            files = Directory.GetFiles(path);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            yield break;
        }

        foreach (var folder in folders) yield return new FileModel(Path.Combine(path, folder), FileTypes.Folder);

        foreach (var file in files) yield return new FileModel(Path.Combine(path, file), FileTypes.Program);
    }
}