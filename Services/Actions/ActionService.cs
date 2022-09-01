using Entities.Files;
using Services.Core.Actions;

namespace Services.Actions;

public class ActionService : IActionService, IDisposable
{
    private bool _isDisposed;
    
    public Action<FileModel> UpdateSideSection { get; set; }
    public Action<string> UpdateMainSection { get; set; }

    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;
        UpdateSideSection = null;
        UpdateMainSection = null;
    }
}