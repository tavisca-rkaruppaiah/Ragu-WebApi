using System;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestForAPI
{
    public class UnitTest1
    {
        ValuesController valuesController = new ValuesController();
        [Fact]
        public void TestCaseForHi()
        {
            string actual = valuesController.Get("hello");
            Assert.Equal("hi", actual);
        }

        [Fact]
        public void TestCaseForHello()
        {
            string actual = valuesController.Get("hi");
            Assert.Equal("hello", actual);
        }
    }
}
