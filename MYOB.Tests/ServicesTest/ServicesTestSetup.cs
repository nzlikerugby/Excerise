using MyServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Tests
{
    public partial class ServicesTests
    {
        private static Services service;
        static ServicesTests()
        {
            service = Services.GetServices();
        }
    }
}
