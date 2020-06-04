using System;
using System.Collections.Generic;
using CheckOutProcess.BLL.Implementation;
using CheckOutProcess.Factory.Implementation;
using CheckOutProcess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CheckOutProcess.UtilityClasses.UtilityFunctions;

using System.Linq;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class PromotionFactoryTests
    {
        //PromotionFactory promotionFactory = null;

        [TestInitialize]
        public void testInit()
        {
            //promotionFactory = new PromotionFactory(PromotionType.THREEAS);
        }

        [TestMethod]
        public void CreatePromotionFactoryTest()
        {
            PromotionFactory promotionFactory = PromotionFactory.CreatePromotionFactory(PromotionType.THREEAS);
            Assert.IsInstanceOfType(promotionFactory, typeof(PromotionFactory));
            Assert.IsTrue((promotionFactory.promotionType == PromotionType.THREEAS));
        }

        [TestMethod]
        public void PromotionPriceListTest()
        {
            PromotionFactory promotionFactory = PromotionFactory.CreatePromotionFactory(PromotionType.THREEAS);
            Assert.IsInstanceOfType(promotionFactory.promotionPriceList, typeof(List<PromotionPrice>));
            Assert.IsTrue((promotionFactory.promotionPriceList.Count == 3));
            Assert.IsTrue((promotionFactory.promotionPriceList[0].Price == 130));
            Assert.IsTrue((promotionFactory.promotionPriceList[1].Price == 45));
            Assert.IsTrue((promotionFactory.promotionPriceList[2].Price == 30));
            Assert.IsTrue((promotionFactory.promotionPriceList[0].Promotion == PromotionType.THREEAS));
            Assert.IsTrue((promotionFactory.promotionPriceList[1].Promotion == PromotionType.TWOBS));
            Assert.IsTrue((promotionFactory.promotionPriceList[2].Promotion == PromotionType.CANDD));
        }

        [TestMethod]
        public void CreatePromotionTypeTest()
        {
            PromotionFactory promotionFactory = PromotionFactory.CreatePromotionFactory(PromotionType.THREEAS);
            List<PromotionPrice> promotionPriceList = promotionFactory.promotionPriceList;
            int price = promotionPriceList.Where(priceList => priceList.Promotion == promotionFactory.promotionType).FirstOrDefault().Price;
            Assert.IsTrue((price == 130));
            Assert.IsInstanceOfType(promotionFactory.CreatePromotionType(), typeof(ThreeAs));
            promotionFactory = promotionFactory = PromotionFactory.CreatePromotionFactory((PromotionType.TWOBS));
            Assert.IsInstanceOfType(promotionFactory.CreatePromotionType(), typeof(TwoBs));
            promotionFactory = promotionFactory = PromotionFactory.CreatePromotionFactory((PromotionType.CANDD));
            Assert.IsInstanceOfType(promotionFactory.CreatePromotionType(), typeof(CandD));
        }
    }
}
