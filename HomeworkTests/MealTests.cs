using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class MealTests
    {
        //初始化測試
        [TestMethod()]
        public void MealTest()
        {
            Category category = new Category("Category");
            Meal meal = new Meal("Test", category, 70, "Path", "Description");
            Assert.AreEqual("Test", meal.Name);
            Assert.AreEqual(category, meal.GetCategory());
            Assert.AreEqual(70, meal.GetPrice());
            Assert.AreEqual("Path", meal.GetImageRelativePath());
            Assert.AreEqual("Description", meal.GetDescribe());
        }

        //取得餐點類別測試
        [TestMethod()]
        public void GetCategoryTest()
        {
            Category category = new Category("Category");
            Meal meal = new Meal("Test", category, 70, "Path", "Description");
            Assert.AreEqual(category, meal.GetCategory());
        }

        //取得餐點類別名稱測試
        [TestMethod()]
        public void GetCategoryNameTest()
        {
            Meal meal = new Meal("Test", new Category("Category"), 70, "Path", "Description");
            Assert.AreEqual("Category", meal.GetCategoryName());
        }

        //取得餐點價格測試
        [TestMethod()]
        public void GetPriceTest()
        {
            Meal meal = new Meal("Test", new Category("Category"), 70, "Path", "Description");
            Assert.AreEqual(70, meal.GetPrice());
        }

        //取得圖檔相對位子測試
        [TestMethod()]
        public void GetImageRelativePathTest()
        {
            Meal meal = new Meal("Test", new Category("Category"), 70, "Path", "Description");
            Assert.AreEqual("Path", meal.GetImageRelativePath());
        }

        //取得餐點描述測試
        [TestMethod()]
        public void GetDescribeTest()
        {
            Meal meal = new Meal("Test", new Category("Category"), 70, "Path", "Description");
            Assert.AreEqual("Description", meal.GetDescribe());
        }

        //判斷是不是同個類別測試
        [TestMethod()]
        public void IsSameCategoryTest()
        {
            Category category1 = new Category("Category1");
            Category category2 = new Category("Category2");
            Meal meal1 = new Meal("Test1", category1, 70, "Path1", "Description1");
            Meal meal2 = new Meal("Test2", category2, 80, "Path2", "Description2");
            Meal meal3 = new Meal("Test3", category1, 90, "Path3", "Description3");
            Assert.AreEqual(false, meal1.IsSameCategory(meal2));
            Assert.AreEqual(true, meal1.IsSameCategory(meal3));
        }

        //通知數值變化測試
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            Meal meal = new Meal("Test", new Category("Category"), 70, "Path", "Description");
            List<string> nameOfPropertyChanged = new List<string>();
            meal.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            meal.NotifyPropertyChanged("Name");
            Assert.AreEqual("Name", nameOfPropertyChanged[0]);
        }
    }
}