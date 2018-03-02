using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic_List_O;

namespace Generic_List_O_Tests
{
    [TestClass]
    public class OListTests
    {
        //implemented according to https://msdn.microsoft.com/en-us/library/ms182532.aspx 
        [TestMethod]
        public void Add_AddsCorrectly()
        {
            //arrange
            object objectToAdd = new object();
            var expected = objectToAdd.GetHashCode();
            OList<object> ListToTest = new OList<object>();

            //act
            ListToTest.Add(objectToAdd);

            //assert
            var actual = ListToTest.GetItem(item => item.GetHashCode() == expected);
            Assert.AreEqual(expected, actual, "Item not added or retrieved correctly");
        }
    }
}
