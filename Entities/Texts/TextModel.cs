using System;
using System.Collections.Concurrent;

namespace Entities.Texts;

public struct TextModel
{
    public Guid Id { get; set; }
    public ConcurrentDictionary<string, string> TextValues { get; set; }

    public string Text(string language)
    {
        return TextValues != null && TextValues.TryGetValue(language, out var result) ? result : "▢";
    }
}