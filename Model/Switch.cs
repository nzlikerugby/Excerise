using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Flags]
    public enum OUTPUTTO
    {
        CONSOLE = 1,
        FILE = 2,
        DATABASE = 4,
        BOTH = CONSOLE | FILE
    }
}
