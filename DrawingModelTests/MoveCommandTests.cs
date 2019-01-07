using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        //移動圖案測試
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model("", "", "", false);
            Line line = new Line();
            Diamond diamond = new Diamond();
            model.AddShape(line);
            MoveCommand moveCommand = new MoveCommand(model, diamond, line, 0);
            moveCommand.Execute();
            Assert.AreEqual(model.GetShapes()[0], diamond);
        }

        //還原移動的圖案測試
        [TestMethod()]
        public void RestoreTest()
        {
            Model model = new Model("", "", "", false);
            Diamond diamond = new Diamond();
            Ellipse ellipse = new Ellipse();
            model.AddShape(diamond);
            MoveCommand moveCommand = new MoveCommand(model, ellipse, diamond, 0);
            moveCommand.Execute();
            Assert.AreEqual(model.GetShapes()[0], ellipse);
            moveCommand.Restore();
            Assert.AreEqual(model.GetShapes()[0], diamond);
        }
    }
}