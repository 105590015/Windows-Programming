using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        //設定圖形測試
        [TestMethod()]
        public void CreateShapeTest()
        {
            Model model = new Model("", "", "", false);
            model.CreateShape("Line");
            Assert.AreEqual(model.GetCommandManager().IsRedoEnabled, false);
        }

        //當鼠標點擊測試
        [TestMethod()]
        public void PressPointerTest()
        {
            Model model = new Model("", "", "", false);
            model.CreateShape("Line");
            model.PressPointer(100, 100);
            Assert.AreEqual(model.GetCommandManager().IsUndoEnabled, false);
        }

        //鼠標移動測試
        [TestMethod()]
        public void MovePointerTest()
        {
            Model model = new Model("", "", "", false);
            model.CreateShape("Line");
            model.PressPointer(100, 100);
            model.MovePointer(110, 110);
            Assert.AreEqual(model.GetCommandManager().IsRedoEnabled, false);
        }

        //放開滑鼠測試
        [TestMethod()]
        public void ReleasePointerTest()
        {
            Model model = new Model("", "", "", false);
            model.CreateShape("Line");
            model.PressPointer(100, 100);
            model.MovePointer(110, 110);
            model.ReleasePointer(110, 110);
            Assert.AreEqual(model.GetCommandManager().IsUndoEnabled, true);
            Assert.AreEqual(model.GetCommandManager().IsRedoEnabled, false);
        }

        //清除圖畫測試
        [TestMethod()]
        public void ClearTest()
        {
            Model model = new Model("", "", "", false);
            model.Clear();
            Assert.AreEqual(model.GetCommandManager().IsUndoEnabled, true);
            Assert.AreEqual(model.GetCommandManager().IsRedoEnabled, false);
        }

        //還原清除畫面測試
        [TestMethod()]
        public void UndoClearTest()
        {
            Model model = new Model("", "", "", false);
            model.Clear();
            model.UndoClear(new List<Shape>());
            Assert.AreEqual(model.GetCommandManager().IsUndoEnabled, true);
        }

        //加入圖案測試
        [TestMethod()]
        public void AddShapeTest()
        {
            Model model = new Model("", "", "", false);
            Line line = new Line();
            line.SetLocation(10, 10, 20, 20);
            model.AddShape(line);
            Assert.AreEqual(model.GetShapes()[0], line);
        }

        //刪除最新的圖案測試
        [TestMethod()]
        public void DeleteShapeTest()
        {
            Model model = new Model("", "", "", false);
            Diamond diamond = new Diamond();
            diamond.SetLocation(10, 20, 20, 40);
            model.AddShape(diamond);
            Assert.AreEqual(model.GetShapes()[0], diamond);
            model.DeleteShape();
            Assert.AreEqual(model.GetShapes().Count, 0);
        }

        //更新圖案測試
        [TestMethod()]
        public void UpdateShapeTest()
        {
            Model model = new Model("", "", "", false);
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(50, 50, 80, 80);
            model.AddShape(ellipse);
            Diamond diamond = new Diamond();
            diamond.SetLocation(20, 40, 40, 80);
            model.UpdateShape(diamond, 0);
            Assert.AreEqual(model.GetShapes()[0], diamond);
        }

        //清空圖案測試
        [TestMethod()]
        public void ClearShapeTest()
        {
            Model model = new Model("", "", "", false);
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(80, 80, 150, 150);
            model.AddShape(ellipse);
            model.ClearShape();
            Assert.AreEqual(model.GetShapes().Count, 0);
        }
    }
}