using Entities.Files;
using Services.Core.FileManagers;

namespace Services.FileManagers;

public class FileManagerService : IFileManagerService
{
    public IEnumerable<FileModel> GetFolderData(string path)
    {
        foreach (var folder in Directory.GetDirectories(path))
        {
            yield return new FileModel(Path.Combine(path, folder));
        }

        foreach (var file in Directory.GetFiles(path))
        {
            yield return new FileModel(Path.Combine(path, file));
        }
    }
}