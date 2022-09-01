using System;
using System.IO;
using Services.Core.Actions;
using Services.Core.PathManagers;

namespace Services.PathManagers;

public class PathManagerService : IPathManagerService
{
    private static class Fields
    {
        public const string TextFile = "text.json";
        public const string ConfigFolder = "config";
        public const string DataFolder = "db";
        public const string DataFile = "data.db";
    }
    
    private readonly string _programFolder;
    
    public PathManagerService(IActionService actionService)
    {
        _programFolder = Directory.GetCurrentDirectory();

        if (!File.Exists(TextJsonFile))
        {
            Directory.CreateDirectory(Path.Combine(_programFolder, Fields.ConfigFolder));
            File.Create(TextJsonFile);
        }

        if (!Directory.Exists(Path.Combine(_programFolder, Fields.DataFolder)))
        {
            Directory.CreateDirectory(Path.Combine(_programFolder, Fields.DataFolder));
        }
        
        actionService.UpdateMainSection += UpdatePath;
    }

    public string DefaultPath => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public string CurrentPath { get; private set; }
    public string CurrentPathFolder => Path.GetDirectoryName(CurrentPath);
    public string TextJsonFile => Path.Combine(_programFolder, Fields.ConfigFolder, Fields.TextFile);
    public string DbPath => Path.Combine(_programFolder, Fields.DataFolder, Fields.DataFile);

    private void UpdatePath(string path)
    {
        CurrentPath = string.IsNullOrEmpty(path) ? DefaultPath : path;
    }
}