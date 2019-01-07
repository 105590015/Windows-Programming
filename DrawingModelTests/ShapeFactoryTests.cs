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
    public class ShapeFactoryTests
    {
        //建立圖案測試
        [TestMethod()]
        public void CreateShapeTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.AreEqual(shapeFactory.CreateShape("Line").GetType(), new Line().GetType());
            Assert.AreEqual(shapeFactory.CreateShape("Diamond").GetType(), new Diamond().GetType());
            Assert.AreEqual(shapeFactory.CreateShape("Ellipse").GetType(), new Ellipse().GetType());
            Assert.AreEqual(shapeFactory.CreateShape(""), null);
        }
    }
}