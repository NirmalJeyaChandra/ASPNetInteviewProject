using System;
using CheckOutProcess.BLL.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class CandDTests
    {
        CandD candDs = null;
        [TestInitialize]
        public void testInit()
        {
            candDs = new CandD(30);
        }

        [TestMethod]
        public void GetPromotionPriceTest()
        {
            Assert.IsTrue((candDs.getPromotionPrice() == 30));
        }
    }
}