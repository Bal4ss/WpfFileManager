using System;

namespace Services.Core.Languages;

public interface ILanguageService
{
    string Text(Guid id);
}