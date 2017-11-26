using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose;

namespace GildedRose.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public Inventory Stock;

        protected void _loadData()
        {
            Stock = new Inventory();
            Stock.Add(new AgedBrie("Aged Brie", 1, 1));
            Stock.Add(new BackstagePasses("Backstage Passes", -1, 2));
            Stock.Add(new BackstagePasses("Backstage Passes", 9, 2));
            Stock.Add(new Sulfuras("Sulfuras", 2, 2));
            Stock.Add(new NormalItem("Normal Item", -1, 55));
            Stock.Add(new NormalItem("Normal Item", 2, 2));
            Stock.Add(new INVALIDITEM("INVALID ITEM", 2, 2));
            Stock.Add(new Conjured("Conjured", 2, 2));
            Stock.Add(new Conjured("Conjured", -1, 5));
        }

        [Ignore]
        [TestMethod]
        public void TestMethod1() 
        {
            _loadData();
            Stock.print(" Initial Inventory");
            Stock.Age();
            Stock.print(" AGED Inventory");

            Assert.AreEqual(Stock.Stock[0].Sellin, 0); //Aged Brie 0 2
            Assert.AreEqual(Stock.Stock[0].Quality, 2);

            Assert.AreEqual(Stock.Stock[1].Sellin, -2); //Backstage Passes -2 0
            Assert.AreEqual(Stock.Stock[1].Quality, 0);

            Assert.AreEqual(Stock.Stock[2].Sellin, 8); //Backstage Passes 8 4
            Assert.AreEqual(Stock.Stock[2].Quality, 4);

            Assert.AreEqual(Stock.Stock[3].Sellin, 2); //Sulfuras 2 2
            Assert.AreEqual(Stock.Stock[3].Quality, 2);

            Assert.AreEqual(Stock.Stock[4].Sellin, -2); //Normal Item -2 50
            Assert.AreEqual(Stock.Stock[4].Quality, 50);

            Assert.AreEqual(Stock.Stock[5].Sellin, 1); //Normal Item 1 1
            Assert.AreEqual(Stock.Stock[5].Quality, 1);

            Assert.AreEqual(Stock.Stock[6].ToString(), "NO SUCH ITEM"); //Normal Item

            Assert.AreEqual(Stock.Stock[7].Sellin, 1); //Conjured 1 0
            Assert.AreEqual(Stock.Stock[7].Quality, 0);

            Assert.AreEqual(Stock.Stock[8].Sellin, -2); //Conjured -2 1
            Assert.AreEqual(Stock.Stock[8].Quality, 1);
        }
    }
}
