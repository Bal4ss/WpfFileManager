using System;
using System.Collections.Concurrent;

namespace Entities.Texts;

/// <summary>
///     Xaml util text model
/// </summary>
public struct TextModel
{
    public Guid Id { get; set; }
    public ConcurrentDictionary<string, string> TextValues { get; set; }

    public string Text(string language)
    {
        return TextValues != null && TextValues.TryGetValue(language, out var result) ? result : "▢";
    }
}