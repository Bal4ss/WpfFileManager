using System;
using Entities.Files;

namespace Services.Core.Actions;

/// <summary>
///     Actions service
/// </summary>
public interface IActionService
{
    Action<FileModel> UpdateSideSection { get; set; }
    Action<string> UpdateMainSection { get; set; }
}