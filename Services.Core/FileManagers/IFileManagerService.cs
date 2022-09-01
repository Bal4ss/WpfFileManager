using Entities.Files;

namespace Services.Core.FileManagers;

/// <summary>
/// File manager service
/// </summary>
public interface IFileManagerService
{
    /// <summary>
    /// Get file model by path
    /// </summary>
    /// <param name="path">path</param>
    /// <returns>list of file models</returns>
    IEnumerable<FileModel> GetFolderData(string path);
}