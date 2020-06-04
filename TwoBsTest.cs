using System;
using CheckOutProcess.BLL.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class TwoBsTest
    {
        TwoBs twoBs = null;
        [TestInitialize]
        public void testInit()
        {
            twoBs = new TwoBs(45);
        }

        [TestMethod]
        public void GetPromotionPriceTest()
        {
            Assert.IsTrue((twoBs.getPromotionPrice() == 45));
        }
    }
}
