using System;

namespace Services.Core.Languages;

/// <summary>
///     Language service
/// </summary>
public interface ILanguageService
{
    /// <summary>
    ///     Get actual text by id
    /// </summary>
    /// <param name="id">text id</param>
    /// <returns>text value</returns>
    string Text(Guid id);
}