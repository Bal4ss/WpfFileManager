using System;
using Entities.Files;
using MySql.Data.MySqlClient;
using Services.Core.DB;
using Services.Core.Settings;

namespace Services.DB;

public class SqLiteService : ISqLiteService, IDisposable
{
    private bool _isDisposed;
    private MySqlConnection _context;

    public SqLiteService(IGlobalSettings gs)
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = gs.Server,
            Database = gs.Database,
            UserID = gs.UserId,
            Password = gs.Password,
            Port = gs.Port
        };

        _context= new MySqlConnection(builder.ConnectionString);
    }

    public void AppendFile(FileModel model)
    {
        _context.Open();

        using var command = _context.CreateCommand();
        
        command.CommandText = @"INSERT INTO open_file_data (file_name, open_date) VALUES (@name, @date);";
        command.Parameters.AddWithValue("@name", model.FileName);
        command.Parameters.AddWithValue("@date", DateTime.Now);
        
        var test = command.ExecuteNonQuery();

        _context.Close();
    }

    public void Dispose()
    {
        if (!_isDisposed)
            return;
        
        _context.Dispose();

        _isDisposed = true;
    }
}