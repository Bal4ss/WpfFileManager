using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Entities.Attributes;
using Entities.Enums;
using Entities.Files;
using Extensions;
using Services.Core.Actions;
using Services.Core.Languages;
using WpfFileManager.ViewModels.Core.SideSections;

namespace WpfFileManager.ViewModels.SideSections;

public class SideSectionVm : BaseViewModel, ISideSectionVm
{
    private readonly ILanguageService _languageService;

    private SmartCollection<AttributeModel> _attributes = new();
    private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    public SideSectionVm(ILanguageService languageService, IActionService actionService)
    {
        _languageService = languageService;

        actionService.UpdateSideSection += UpdateAttributes;
    }

    public ReadOnlyObservableCollection<AttributeModel> Attributes => new(_attributes);

    private void UpdateAttributes(FileModel model)
    {
        _attributes = new SmartCollection<AttributeModel>();

        try
        {
            if (model.Type == FileTypes.Folder)
                UpdateFolderAttributes(model.FullPath);
            else
                UpdateFileAttributes(model.FullPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _attributes.Add(new AttributeModel
            {
                Name = _languageService.Text(new Guid("E652A05D-9309-42BD-BCDB-1D8AAA3655A6")),
                Value = "",
            });
        }

        RaisePropertyChanged(nameof(Attributes));
    }

    private void UpdateFileAttributes(string path)
    {
        var fileInfo = new FileInfo(path);
        
        _attributes.Add(new AttributeModel
        {
            Name = _languageService.Text(new Guid("ED0A0A03-F741-43CC-99D4-2B683C6836AA")),
            Value = SizeSuffix(fileInfo.Length),
        });
        
        _attributes.Add(new AttributeModel
        {
            Name = _languageService.Text(new Guid("F0568302-B2C4-418A-97BD-A79FE38EC2F4")),
            Value = $"{fileInfo.CreationTime:dd.MM.yyyy HH:mm:ss}",
        });
    }

    private void UpdateFolderAttributes(string path)
    {
        var folderInfo = new DirectoryInfo(path);
        
        _attributes.Add(new AttributeModel
        {
            Name = _languageService.Text(new Guid("B58543B2-88F2-4725-94D7-D942C9D695E0")),
            Value = SizeSuffix(folderInfo.GetFiles().Select(c => c.Length).Sum()),
        });
        
        _attributes.Add(new AttributeModel
        {
            Name = _languageService.Text(new Guid("552B6C4D-8D19-47C4-BD1A-7F6519874C94")),
            Value = $"{folderInfo.GetFiles().Length + folderInfo.GetDirectories().Length}",
        });
    }

    static string SizeSuffix(long value, int decimalPlaces = 1)
    {
        if (value < 0)
            return $"-{SizeSuffix(-value, decimalPlaces)}";

        var i = 0;
        var dValue = (decimal)value;
        while (Math.Round(dValue, decimalPlaces) >= 1000)
        {
            dValue /= 1024;
            i++;
        }

        return $"{dValue:N1} {SizeSuffixes[i]}";
    }
}