using System;
using System.Collections.Generic;
using CheckOutProcess.DAL.Implementation;
using CheckOutProcess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckOutProcessUnitTest
{
    [TestClass]
    public class SkuPriceDALTests
    {
        SkuPricesDAL skuPricesDAL = null;

        [TestInitialize]
        public void testInit()
        {
            skuPricesDAL = SkuPricesDAL.CreateSkuPricesDAL();
           
        }

        [TestMethod]
        public void CreateSkuPricesDALTest()
        {
            Assert.IsInstanceOfType(skuPricesDAL, typeof(SkuPricesDAL));            
        }

        [TestMethod]
        public void GetSkuPriceListTest()
        {            
            Assert.IsInstanceOfType(skuPricesDAL.GetSkuPriceList(), typeof(List<SkuPrice>));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList().Count == 4));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[0].Price == 50));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[1].Price == 30));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[2].Price == 20));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[3].Price == 15));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[0].SKUId == 'A'));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[1].SKUId == 'B'));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[2].SKUId == 'C'));
            Assert.IsTrue((skuPricesDAL.GetSkuPriceList()[3].SKUId == 'D'));
        }
    }
}
