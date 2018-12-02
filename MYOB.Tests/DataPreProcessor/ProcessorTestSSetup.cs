using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using MyDataIO;
using MyDataPreProcessor;
using MyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace MYOB.Tests
{
    public partial class DataPreProcessorTests
    {
        private IDataPreProcessor processor; 
        [TestInitialize]
        public void Init()
        {
            processor = DataPreProcessor.GetProcessor();
        }

    }
}
