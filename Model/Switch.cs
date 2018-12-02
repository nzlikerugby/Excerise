using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [Flags]
    public enum OUTPUTTO
    {
        // Output to Console only
        CONSOLE = 1,
        // Output to File only
        FILE = 2,
        // Output to All (might be more in future)
        // CONSOLE | FILE | DATABASE
        MANY = CONSOLE | FILE  
    }
}
