using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class OrderTests
    {
        //初始化測試
        [TestMethod()]
        public void OrderTest()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            Assert.AreEqual("Test", order.Name);
            Assert.AreEqual("漢堡", order.Category);
            Assert.AreEqual("80元", order.Price);
            Assert.AreEqual(1, order.Quantity);
            Assert.AreEqual("80元", order.Subtotal);
        }

        //數量加一測試
        [TestMethod()]
        public void AddQuantityTest()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            order.AddQuantity();
            Assert.AreEqual(2, order.Quantity);
            Assert.AreEqual("160元", order.Subtotal);
        }

        //設定數量測試
        [TestMethod()]
        public void SetQuantityTest()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            order.Quantity = 3;
            Assert.AreEqual(3, order.Quantity);
            Assert.AreEqual("240元", order.Subtotal);
        }

        //由於餐點資料改變而重設資料測試
        [TestMethod()]
        public void ResetDataTest1()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            Meal meal = new Meal("Meal", new Category("Category"), 50, "Path", "Description");
            order.ResetData(meal);
            Assert.AreEqual("Meal", order.Name);
            Assert.AreEqual("Category", order.Category);
            Assert.AreEqual("50元", order.Price);
            Assert.AreEqual("50元", order.Subtotal);
        }

        //由於類別資料改變而重設資料
        [TestMethod()]
        public void ResetDataTest2()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            Category category = new Category("Category");
            order.ResetData(category);
            Assert.AreEqual("Category", order.Category);
        }

        //通知數值變化測試
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            Order order = new Order("Test", "漢堡", 80, 1, 80);
            List<string> nameOfPropertyChanged = new List<string>();
            order.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            order.NotifyPropertyChanged("Name");
            Assert.AreEqual("Name", nameOfPropertyChanged[0]);
        }
    }
}