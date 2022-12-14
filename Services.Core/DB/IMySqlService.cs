using Entities.Files;

namespace Services.Core.DB;

/// <summary>
///     Sql logic service
/// </summary>
public interface IMySqlService
{
    /// <summary>
    ///     Append new file to data
    /// </summary>
    /// <param name="model">file model</param>
    void AppendFile(FileModel model);
}