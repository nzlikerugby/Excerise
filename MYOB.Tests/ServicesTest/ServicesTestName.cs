using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyServices;
using System;

namespace MYOB.Tests
{
    [TestClass]
    public  partial class ServicesTests
    {
        [TestMethod]
        public void Test_OutputName_When_Input_Correct()
        {
            // Arrange
            string firstName = "Tom";
            string lastName = "Hanks";
            
            // Act
            string output = service.OutputName(firstName, lastName);

            // Assert
            Assert.AreEqual("Tom Hanks",output);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "NAME CANNOT BE NULL OR EMPTY")]
        public void Test_OutputName_When_Input_Null()
        {
            // Arrange
            string firstName = null;
            string lastName = "Hanks";
            
            // Act
            string output = service.OutputName(firstName, lastName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "NAME CANNOT BE NULL OR EMPTY")]
        public void Test_OutputName_When_Input_Empty()
        {
            // Arrange
            string firstName = null;
            string lastName = "Hanks";
            
            // Act
            string output = service.OutputName(firstName, lastName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "NAME CANNOT BE MORE THAN 20 CHARACTERS")]
        public void Test_OutputName_When_Input_Name_Length_Too_Long()
        {
            // Arrange
            string firstName = "Helloworldisworldfirstinterestingprograme";
            string lastName = "Hanks";
            
            // Act
            string output = service.OutputName(firstName, lastName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "NAME CAN ONLY CONTAINS ENGLISH CHARACTER")]
        public void Test_OutputName_When_Input_Name_Contains_Non_English_Character()
        {
            // Arrange
            string firstName = "T1#Helloworldisworldfirstinterestingprograme";
            string lastName = "Hanks";
            
            // Act
            string output = service.OutputName(firstName, lastName);
        }
    }
}
