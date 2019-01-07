using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class LineTests
    {
        //設定位子測試
        [TestMethod()]
        public void SetLocationTest()
        {
            Line line = new Line();
            line.SetLocation(10, 10, 20, 20);
            Assert.AreEqual(line.GetInformation(), "Line,10,10,20,20");
        }

        //移動位子測試
        [TestMethod()]
        public void MoveLocationTest()
        {
            Line line = new Line();
            line.SetLocation(0, 0, 10, 10);
            line.MoveLocation(5, 5);
            Assert.AreEqual(line.GetInformation(), "Line,5,5,15,15");
        }

        //複製測試
        [TestMethod()]
        public void CloneTest()
        {
            Line Line = new Line();
            Line.SetLocation(30, 30, 10, 10);
            Shape cloneLine = Line.Clone(false);
            Assert.AreEqual(cloneLine.GetInformation(), "Line,30,30,10,10");
        }

        //是否被點擊測試
        [TestMethod()]
        public void IsClickedTest()
        {
            Line Line = new Line();
            Line.SetLocation(50, 50, 100, 100);
            Assert.AreEqual(Line.IsClicked(75, 75), true);
        }
    }
}