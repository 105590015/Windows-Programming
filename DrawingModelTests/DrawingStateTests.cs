using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        //當鼠標點擊，紀錄點擊位子測試
        [TestMethod()]
        public void PressPointerTest()
        {
            Model model = new Model("", "", "", false);
            Line line = new Line();
            DrawingState drawingState = new DrawingState(model, model.GetCommandManager(), line);
            Assert.AreEqual(drawingState.PressPointer(10, 10), line);
        }

        //更新(按壓著時)鼠標移動的位子測試
        [TestMethod()]
        public void MovePointerTest()
        {
            Model model = new Model("", "", "", false);
            Diamond diamond = new Diamond();
            DrawingState drawingState = new DrawingState(model, model.GetCommandManager(), diamond);
            Assert.AreEqual(drawingState.MovePointer(30,30), diamond);
        }

        //放開滑鼠，進行畫圖測試
        [TestMethod()]
        public void ReleasePointerTest()
        {
            Model model = new Model("", "", "", false);
            Ellipse ellipse = new Ellipse();
            DrawingState drawingState = new DrawingState(model, model.GetCommandManager(), ellipse);
            drawingState.ReleasePointer(30, 30);
            Assert.AreNotEqual(model.GetShapes()[0], ellipse);
        }
    }
}