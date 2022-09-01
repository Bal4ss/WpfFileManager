using System;
using Entities.Files;
using MySql.Data.MySqlClient;
using Services.Core.DB;
using Services.Core.Settings;

namespace Services.DB;

public class MySqlService : IMySqlService, IDisposable
{
    private readonly MySqlConnection _context;
    private bool _isDisposed;

    public MySqlService(IGlobalSettings gs)
    {
        var builder = new MySqlConnectionStringBuilder
        {
            Server = gs.Server,
            Database = gs.Database,
            UserID = gs.UserId,
            Password = gs.Password,
            Port = gs.Port
        };

        _context = new MySqlConnection(builder.ConnectionString);
    }

    public void Dispose()
    {
        if (!_isDisposed)
            return;

        _context.Dispose();

        _isDisposed = true;
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
}