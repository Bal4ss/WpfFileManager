using System;

namespace Extensions;

public class Error
{
    public static Exception ArgumentNull(string name)
        => new ArgumentNullException(name);
}