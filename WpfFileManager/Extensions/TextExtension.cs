using System;
using System.Windows.Markup;
using Autofac;
using Services.Core.Languages;

namespace WpfFileManager.Extensions;

/// <summary>
/// Xaml text extension
/// </summary>
public class TextExtension : MarkupExtension
{
    private readonly Guid _textId;
    
    public TextExtension(string textId)
    {
        _textId = Guid.Parse(textId);
    }
    
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var languageService = AutoFac.Default.Container.Resolve<ILanguageService>();

        return languageService.Text(_textId);
    }
}