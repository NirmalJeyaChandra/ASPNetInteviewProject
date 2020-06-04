using System;
using System.Collections.Generic;
using CheckOutProcess.BLL.Abstraction;
using CheckOutProcess.BLL.Implementation;
using CheckOutProcess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class PromotionEngineTests
    {
        IPromotionEngine promotionEngine = null;

        [TestInitialize]
        public void testInit()
        {
            promotionEngine = PromotionEngine.CreatePromotionEngine();
        }

        [TestMethod]
        public void CreatePromotionEngineTest()
        {
            Assert.IsInstanceOfType(promotionEngine, typeof(IPromotionEngine));
        }

        [TestMethod]
        public void GetSkuPriceListTest()
        {
            Assert.IsInstanceOfType(promotionEngine.GetSkuPriceList(), typeof(List<SkuPrice>));
            Assert.IsTrue(promotionEngine.GetSkuPriceList().Count > 0);
        }

        [TestMethod]
        public void GetTotalOrderValueTestScenario1()
        {
            Dictionary<char, int> orderList = new Dictionary<char, int>();
            string[] arguments = { "1", "1", "1", "0" };
            orderList.Add('A', Convert.ToInt32(arguments[0]));
            orderList.Add('B', Convert.ToInt32(arguments[1]));
            orderList.Add('C', Convert.ToInt32(arguments[2]));
            orderList.Add('D', Convert.ToInt32(arguments[3]));

            Assert.IsTrue(promotionEngine.GetTotalOrderValue(orderList) == 100);
        }

        [TestMethod]
        public void GetTotalOrderValueTestScenario2()
        {
            Dictionary<char, int> orderList = new Dictionary<char, int>();
            string[] arguments2 = { "5", "5", "1", "0" };
            orderList.Add('A', Convert.ToInt32(arguments2[0]));
            orderList.Add('B', Convert.ToInt32(arguments2[1]));
            orderList.Add('C', Convert.ToInt32(arguments2[2]));
            orderList.Add('D', Convert.ToInt32(arguments2[3]));

            Assert.IsTrue(promotionEngine.GetTotalOrderValue(orderList) == 370);
        }
        [TestMethod]
        public void GetTotalOrderValueTestScenario3()
        {
            Dictionary<char, int> orderList = new Dictionary<char, int>();
            string[] arguments = new string[] { "3", "5", "1", "1" };
            orderList.Add('A', Convert.ToInt32(arguments[0]));
            orderList.Add('B', Convert.ToInt32(arguments[1]));
            orderList.Add('C', Convert.ToInt32(arguments[2]));
            orderList.Add('D', Convert.ToInt32(arguments[3]));
            Assert.IsTrue(promotionEngine.GetTotalOrderValue(orderList) == 280);
        }
    }
}
