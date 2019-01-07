using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class DiamondTests
    {
        //設定位子測試
        [TestMethod()]
        public void SetLocationTest()
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(10, 10, 20, 20);
            Assert.AreEqual(diamond.GetInformation(), "Diamond,10,10,20,20");
        }

        //移動位子測試
        [TestMethod()]
        public void MoveLocationTest()
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(0, 0, 10, 10);
            diamond.MoveLocation(5, 5);
            Assert.AreEqual(diamond.GetInformation(), "Diamond,5,5,15,15");
        }

        //複製測試
        [TestMethod()]
        public void CloneTest()
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(30, 30, 10, 10);
            Shape cloneDiamond = diamond.Clone(false);
            Assert.AreEqual(cloneDiamond.GetInformation(), "Diamond,30,30,10,10");
        }

        //是否被點擊測試
        [TestMethod()]
        public void IsClickedTest()
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(50, 50, 100, 100);
            Assert.AreEqual(diamond.IsClicked(75, 75), true);
        }
    }
}