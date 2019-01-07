using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class EllipseTests
    {
        //設定位子測試
        [TestMethod()]
        public void SetLocationTest()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(10, 10, 20, 20);
            Assert.AreEqual(ellipse.GetInformation(), "Ellipse,10,10,20,20");
        }

        //移動位子測試
        [TestMethod()]
        public void MoveLocationTest()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(0, 0, 10, 10);
            ellipse.MoveLocation(5, 5);
            Assert.AreEqual(ellipse.GetInformation(), "Ellipse,5,5,15,15");
        }

        //複製測試
        [TestMethod()]
        public void CloneTest()
        {
            Ellipse Ellipse = new Ellipse();
            Ellipse.SetLocation(30, 30, 10, 10);
            Shape cloneEllipse = Ellipse.Clone(false);
            Assert.AreEqual(cloneEllipse.GetInformation(), "Ellipse,30,30,10,10");
        }

        //是否被點擊測試
        [TestMethod()]
        public void IsClickedTest()
        {
            Ellipse Ellipse = new Ellipse();
            Ellipse.SetLocation(50, 50, 100, 100);
            Assert.AreEqual(Ellipse.IsClicked(75, 75), true);
        }
    }
}