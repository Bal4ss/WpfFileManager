using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Entities.Texts;
using Extensions;
using Services.Core.Json;
using Services.Core.Languages;
using Services.Core.PathManagers;
using Services.Core.Settings;

namespace Services.Languages;

public class LanguageService : ILanguageService
{
    private readonly IGlobalSettings _gs;

    private readonly ConcurrentDictionary<Guid, TextModel> _textModels;

    public LanguageService(IPathManagerService pathManagerService, IGlobalSettings gs, IJsonService jsonService)
    {
        _gs = gs;

        var textModels = jsonService.GetJsonFromFile<IEnumerable<TextModel>>(pathManagerService.TextJsonFile)?.ToList();
        if (textModels?.Any() != true)
        {
            textModels = new List<TextModel>(DefaultText());
            jsonService.WriteJsonFile(textModels, pathManagerService.TextJsonFile);
        }

        _textModels = textModels.ToConcurrentDictionary(k => k.Id, v => v);
    }

    public string Text(Guid id)
    {
        if (_textModels != null && _textModels.TryGetValue(id, out var text))
            return text.Text(_gs.Language);
        return "";
    }

    private IEnumerable<TextModel> DefaultText()
    {
        yield return new TextModel
        {
            Id = new Guid("cbbfd588-2b18-4224-93c0-4b869fbd9e48"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Поиск"
            }
        };
        yield return new TextModel
        {
            Id = new Guid("B58543B2-88F2-4725-94D7-D942C9D695E0"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Размер файлов в папке: "
            }
        };
        yield return new TextModel
        {
            Id = new Guid("552B6C4D-8D19-47C4-BD1A-7F6519874C94"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Кол-во файлов в папке: "
            }
        };
        yield return new TextModel
        {
            Id = new Guid("ED0A0A03-F741-43CC-99D4-2B683C6836AA"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Размер файла: "
            }
        };
        yield return new TextModel
        {
            Id = new Guid("F0568302-B2C4-418A-97BD-A79FE38EC2F4"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Дата создания: "
            }
        };
        yield return new TextModel
        {
            Id = new Guid("E652A05D-9309-42BD-BCDB-1D8AAA3655A6"),
            TextValues = new ConcurrentDictionary<string, string>
            {
                ["ru"] = "Доступ запрещен"
            }
        };
    }
}