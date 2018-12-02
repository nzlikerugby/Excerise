using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYOB.Tests
{
    public partial class ServicesTests
    {
        [TestMethod]
        public void Test_OutputNetIncome_Normal_Input()
        {
            int income = 5004;
            int tax = 922;
            int actual = service.OutputNetIncome(income, tax);
            Assert.AreEqual(income - tax, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "INCOME MUST BE GREATER THAN TAX")]
        public void Test_OutputNetIncome_When_Income_Less_Than_Tax()
        {
            int income = 5004;
            int tax = 5005;
            int actual = service.OutputNetIncome(income, tax);
            Assert.AreEqual(income - tax, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "AMOUNT CANNOT BE NULL")]
        public void Test_OutputNetIncome_When_Income_Or_Tax_Is_Null()
        {
            int? income = 5004;
            int? tax = null;
            int actual = service.OutputNetIncome(income, tax);
            Assert.AreEqual(income - tax, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "AMOUNT MUST BE GREATER THAN 0")]
        public void Test_OutputNetIncome_When_Income_Or_Tax_Less_Than_0()
        {
            int? income = 100;
            int? tax = -2;
            int actual = service.OutputNetIncome(income, tax);
            Assert.AreEqual(income - tax, actual);
        }
    }
}
