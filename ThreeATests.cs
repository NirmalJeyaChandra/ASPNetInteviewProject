using System;
using CheckOutProcess.BLL.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class ThreeATests
    {
        ThreeAs threeAs = null;
        [TestInitialize]
        public void testInit()
        {
            threeAs = new ThreeAs(130);
        }

        [TestMethod]
        public void GetPromotionPriceTest()
        {
            Assert.IsTrue((threeAs.getPromotionPrice() == 130));
        }
    }
}
