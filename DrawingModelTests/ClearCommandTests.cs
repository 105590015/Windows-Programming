using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ClearCommandTests
    {
        //初始化測試測試
        [TestMethod()]
        public void ClearCommandTest()
        {
            Model model = new Model("", "", "", false);
            ClearCommand clearCommand = new ClearCommand(model, new List<Shape>());
            Assert.AreNotEqual(clearCommand, null);
        }

        //清空圖案測試
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model("", "", "", false);
            ClearCommand clearCommand = new ClearCommand(model, new List<Shape>());
            clearCommand.Execute();
            Assert.AreEqual(model.GetShapes().Count, 0);
        }

        //還原清空的圖案測試
        [TestMethod()]
        public void RestoreTest()
        {
            Model model = new Model("", "", "", false);
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Line());
            ClearCommand clearCommand = new ClearCommand(model, shapes);
            clearCommand.Execute();
            Assert.AreEqual(model.GetShapes().Count, 0);
            clearCommand.Restore();
            Assert.AreEqual(model.GetShapes().Count, 1);
        }
    }
}