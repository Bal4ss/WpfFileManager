using System.Configuration;
using Services.Core.Settings;

namespace Services.Settings;

public class GlobalSettings : IGlobalSettings
{
    private static class Fields
    {
        public const string Language = "language";
        public const string AppSettings = "appSettings";
        public const string Server = "server";
        public const string Database = "database";
        public const string UserId = "userId";
        public const string Password = "password";
        public const string Port = "port";
    }

    public GlobalSettings()
    {
        
    }
    
    public string Language
    {
        get => GetValue(Fields.Language) ?? "ru";
        set => AttrSave(Fields.Language, value);
    }

    public string Server => GetValue(Fields.Server);

    public string Database => GetValue(Fields.Database);

    public string UserId => GetValue(Fields.UserId);

    public string Password => GetValue(Fields.Password);

    public uint Port => uint.TryParse(GetValue(Fields.Port), out var result) ? result : 3306;

    private void AttrSave(string attribute, string attrValue)
    {
        var oConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
        oConfig.AppSettings.Settings[attribute].Value = attrValue;
        oConfig.Save(ConfigurationSaveMode.Full);
            
        ConfigurationManager.RefreshSection(Fields.AppSettings);
    }

    private string GetValue(string attributeName) => ConfigurationManager.AppSettings[attributeName];
}