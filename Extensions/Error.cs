using System;

namespace Extensions;

/// <summary>
///     Errors description
/// </summary>
public class Error
{
    public static Exception ArgumentNull(string name)
    {
        return new ArgumentNullException(name);
    }
}