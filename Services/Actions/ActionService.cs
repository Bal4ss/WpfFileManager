using System;
using Entities.Files;
using Services.Core.Actions;

namespace Services.Actions;

public class ActionService : IActionService
{
    public Action<FileModel> UpdateSideSection { get; set; }
    public Action<string> UpdateMainSection { get; set; }
}