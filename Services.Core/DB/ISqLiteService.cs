using Entities.Files;

namespace Services.Core.DB;

public interface ISqLiteService
{
    void AppendFile(FileModel model);
}