using Entities.Files;

namespace Services.Core.Actions;

public interface IActionService
{
    Action<FileModel> UpdateSideSection { get; set; }
    Action<string> UpdateMainSection { get; set; }
}