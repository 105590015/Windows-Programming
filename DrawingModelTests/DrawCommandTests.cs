using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        //新增圖案測試
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model("", "", "", false);
            Line line = new Line();
            DrawCommand drawCommand = new DrawCommand(model, line);
            drawCommand.Execute();
            Assert.AreEqual(model.GetShapes()[0], line);
        }

        //刪除最新的圖案測試
        [TestMethod()]
        public void RestoreTest()
        {
            Model model = new Model("", "", "", false);
            Diamond diamond = new Diamond();
            DrawCommand drawCommand = new DrawCommand(model, diamond);
            drawCommand.Execute();
            Assert.AreEqual(model.GetShapes()[0], diamond);
            drawCommand.Restore();
            Assert.AreEqual(model.GetShapes().Count, 0);
        }
    }
}