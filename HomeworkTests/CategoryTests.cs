using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class CategoryTests
    {
        //初始化測試
        [TestMethod()]
        public void CategoryTest()
        {
            Category category = new Category("Test");
            Assert.AreEqual("Test", category.Name);
        }

        //取得屬於此類別的餐點列表測試
        [TestMethod()]
        public void GetMealsTest()
        {
            Category category = new Category("Test");
            Assert.AreEqual(0, category.GetMeals().Count);
            category.AddMeal(new Meal("Test", category, 60, "", ""));
            Assert.AreEqual(1, category.GetMeals().Count);
        }

        //新增屬此類別的餐點測試
        [TestMethod()]
        public void AddMealTest()
        {
            Category category = new Category("Test");
            category.AddMeal(new Meal("Test", category, 60, "", ""));
            Assert.AreEqual("Test", category.GetMeals()[0].Name);
        }

        //修改餐點資料測試
        [TestMethod()]
        public void EditMealTest()
        {
            Category category = new Category("Test");
            category.AddMeal(new Meal("Test", category, 60, "", ""));
            category.EditMeal(new Meal("Test2", category, 70, "", ""), "Test");
            Assert.AreEqual("Test2", category.GetMeals()[0].Name);
        }

        //清除此類別的餐點測試
        [TestMethod()]
        public void ClearMealsTest()
        {
            Category category = new Category("Test");
            BindingList<Meal> meals = new BindingList<Meal>();
            Meal meal = new Meal("Test", category, 60, "", "");
            category.AddMeal(meal);
            meals.Add(meal);
            category.ClearMeals(meals);
            Assert.AreEqual(0, meals.Count);
        }

        //通知數值變化測試
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            Category category = new Category("Test");
            List<string> nameOfPropertyChanged = new List<string>();
            category.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            category.NotifyPropertyChanged("Name");
            Assert.AreEqual("Name", nameOfPropertyChanged[0]);
        }
    }
}