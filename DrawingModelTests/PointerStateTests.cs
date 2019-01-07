using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        //當鼠標點擊，判斷是不是點擊形狀測試
        [TestMethod()]
        public void PressPointerTest()
        {
            Model model = new Model("", "", "", false);
            Diamond diamond = new Diamond();
            diamond.SetLocation(10, 10, 50, 50);
            Diamond diamond2 = new Diamond();
            diamond2.SetLocation(10, 10, 20, 20);
            model.AddShape(diamond);
            model.AddShape(diamond2);
            PointerState pointerState = new PointerState(model, model.GetCommandManager(), model.GetShapes());
            Assert.AreNotEqual(pointerState.PressPointer(30, 30), diamond);
        }

        //更新(按壓著時)鼠標移動的位子測試
        [TestMethod()]
        public void MovePointerTest()
        {
            Model model = new Model("", "", "", false);
            Ellipse ellipse = new Ellipse();
            ellipse.SetLocation(50, 50, 80, 80);
            model.AddShape(ellipse);
            PointerState pointerState = new PointerState(model, model.GetCommandManager(), model.GetShapes());
            Assert.AreNotEqual(pointerState.MovePointer(30, 30), ellipse);
            pointerState.PressPointer(65, 65);
            Assert.AreNotEqual(pointerState.MovePointer(50, 50), ellipse);
        }

        //放開滑鼠，進行畫圖測試
        [TestMethod()]
        public void ReleasePointerTest()
        {
            Model model = new Model("", "", "", false);
            Line line = new Line();
            line.SetLocation(50, 50, 80, 80);
            model.AddShape(line);
            PointerState pointerState = new PointerState(model, model.GetCommandManager(), model.GetShapes());
            pointerState.ReleasePointer(30, 30);
            Assert.AreEqual(model.GetShapes()[0], line);
            pointerState.PressPointer(65, 65);
            pointerState.ReleasePointer(50, 50);
            Assert.AreEqual(model.GetShapes().Count, 1);
        }
    }
}