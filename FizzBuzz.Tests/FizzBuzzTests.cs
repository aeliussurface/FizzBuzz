using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;

namespace FizzBuzz.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            FizzBuzzer.FirstDivisor = 3;
            FizzBuzzer.SecondDivisor = 5;
        }

        [TestMethod]
        public async Task ShouldThrowArgumentExceptionIfStartingValueIsLessThanEndingValue()
        {
            int startingValue = 3;
            int endingValue = 2;

            var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(() => 
              Task.FromResult(FizzBuzzer.PrintValues(startingValue, endingValue)));

            Assert.AreEqual("startingValue", exception.ParamName);
        }

        [DataTestMethod]
        [DataRow("Fizz", 6)]
        [DataRow("Buzz", 5)]
        [DataRow("4", 4)]
        [DataRow("14", 14)]
        [DataRow("FizzBuzz", 15)]        
        [DataRow("FizzBuzz", 45)]        
        public void ShouldGetStringValueForNumber(string expectedStringValue, int value)
        {
            var stringValue = FizzBuzzer.GetValueForNumber(value);

            Assert.AreEqual(expectedStringValue, stringValue);
        }        
    }
}
