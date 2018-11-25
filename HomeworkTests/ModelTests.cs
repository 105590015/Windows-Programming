using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private int observerTest = 0;
        //初始化測試
        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model();
            Assert.AreEqual("漢堡", model.CategoriesList[0].Name);
            Assert.AreEqual("飲料", model.CategoriesList[2].Name);
            Assert.AreEqual("大麥克", model.MealsList[0].Name);
            Assert.AreEqual("烏龍茶", model.MealsList[26].Name);
            Assert.AreEqual("大麥克", model.CategoriesList[0].GetMeals()[0].Name);
            Assert.AreEqual("經典脆雞堡", model.CategoriesList[0].GetMeals()[14].Name);
            Assert.AreEqual("卡啦雞腿堡餐", model.CategoriesList[1].GetMeals()[0].Name);
            Assert.AreEqual("霸王捲套餐", model.CategoriesList[1].GetMeals()[5].Name);
            Assert.AreEqual("檸檬紅茶", model.CategoriesList[2].GetMeals()[0].Name);
            Assert.AreEqual("烏龍茶", model.CategoriesList[2].GetMeals()[5].Name);
            Assert.AreEqual("Page：1 / 2", model.GetComputeModel().GetPageInformation());
        }

        //儲存與取得被點擊的餐點測試
        [TestMethod()]
        public void SelectMealAndGetSelectedMealTest()
        {
            Model model = new Model();
            //初始頁測試
            model.SelectMeal(0);
            Assert.AreEqual(model.MealsList[0], model.GetSelectedMeal());
            //換頁後測試
            model.GetComputeModel().ChangePage(11);
            model.SelectMeal(1);
            Assert.AreEqual(model.MealsList[10], model.GetSelectedMeal());
            //換類別後測試
            model.ChangeCategory(1);
            model.SelectMeal(2);
            Assert.AreEqual(model.MealsList[17], model.GetSelectedMeal());
        }

        //取得對應名稱的類別測試
        [TestMethod()]
        public void GetCategoryByNameTest()
        {
            Model model = new Model();
            Assert.AreEqual(model.CategoriesList[0], model.GetCategoryByName("漢堡"));
            Assert.AreEqual(model.CategoriesList[1], model.GetCategoryByName("套餐"));
            Assert.AreEqual(model.CategoriesList[2], model.GetCategoryByName("飲料"));
        }

        //切換類別頁面並更新頁碼資訊測試
        [TestMethod()]
        public void ChangeCategoryTest()
        {
            Model model = new Model();
            model.ChangeCategory(1);
            Assert.AreEqual("Page：1 / 1", model.GetComputeModel().GetPageInformation());
            model.ChangeCategory(0);
            Assert.AreEqual("Page：1 / 2", model.GetComputeModel().GetPageInformation());
            model.ChangeCategory(2);
            Assert.AreEqual("Page：1 / 1", model.GetComputeModel().GetPageInformation());
        }

        //取得總金額資訊測試
        [TestMethod()]
        public void GetTotalPriceInformationTest()
        {
            Model model = new Model();
            Assert.AreEqual("Total：0元", model.GetTotalPriceInformation());
            model.SelectMeal(0);
            model.AddOrder();
            Assert.AreEqual("Total：79元", model.GetTotalPriceInformation());
            model.SelectMeal(8);
            model.AddOrder();
            Assert.AreEqual("Total：188元", model.GetTotalPriceInformation());
        }

        //加點餐點測試
        [TestMethod()]
        public void AddOrderTest()
        {
            Model model = new Model();
            model.SelectMeal(0);
            model.AddOrder();
            Assert.AreEqual(1, model.OrdersList.Count);
            Assert.AreEqual("大麥克", model.OrdersList[0].Name);
            Assert.AreEqual(1, model.OrdersList[0].Quantity);
            model.SelectMeal(6);
            model.AddOrder();
            Assert.AreEqual(2, model.OrdersList.Count);
            Assert.AreEqual("煙燻脆雞堡", model.OrdersList[1].Name);
            Assert.AreEqual(1, model.OrdersList[1].Quantity);
            model.SelectMeal(0);
            model.AddOrder();
            Assert.AreEqual(2, model.OrdersList.Count);
            Assert.AreEqual("大麥克", model.OrdersList[0].Name);
            Assert.AreEqual(2, model.OrdersList[0].Quantity);
        }

        //刪除點餐測試
        [TestMethod()]
        public void DeleteOrderTest()
        {
            Model model = new Model();
            model.GetComputeModel().SetSelectedMealOfRestaurant(3);
            model.SelectMeal(2);
            model.AddOrder();
            model.DeleteOrder(0);
            Assert.AreEqual(0, model.OrdersList.Count);
            model.SelectMeal(3);
            model.AddOrder();
            model.SelectMeal(4);
            model.AddOrder();
            model.DeleteOrder(1);
            Assert.AreEqual(1, model.OrdersList.Count);
        }

        //因菜單改變而更新訂單測試
        [TestMethod()]
        public void RefreshOrderTest()
        {
            Model model = new Model();
            Meal meal = new Meal("Test", model.CategoriesList[0], 70, "/Image/meal01.png", "");
            model.SelectMeal(2);
            model.AddOrder();
            model.RefreshOrder(model.MealsList[2], meal);
            Assert.AreEqual("Test", model.OrdersList[0].Name);
        }

        //因類別改變而更新訂單測試
        [TestMethod()]
        public void RefreshOrderTest1()
        {
            Model model = new Model();
            Category category = new Category("Test");
            model.SelectMeal(3);
            model.AddOrder();
            model.RefreshOrder(model.CategoriesList[0], category);
            Assert.AreEqual("Test", model.OrdersList[0].Category);
        }

        //清空點餐測試
        [TestMethod()]
        public void ClearOrdersTest()
        {
            Model model = new Model();
            model.SelectMeal(4);
            model.AddOrder();
            Assert.AreEqual(1, model.OrdersList.Count);
            model.ClearOrders();
            Assert.AreEqual(0, model.OrdersList.Count);
        }

        //修改餐點測試
        [TestMethod()]
        public void EditMealTest()
        {
            Model model = new Model();
            Meal meal1 = new Meal("Test1", model.CategoriesList[0], 70, "/Image/meal01.png", "");
            Meal meal2 = new Meal("Test2", model.CategoriesList[1], 90, "/Image/meal16.png", "");
            model.EditMeal(meal1, 1);
            Assert.AreEqual("Test1", model.MealsList[1].Name);
            Assert.AreEqual("Test1", model.CategoriesList[0].GetMeals()[1].Name);
            model.EditMeal(meal2, 2);
            Assert.AreEqual("Test2", model.MealsList[2].Name);
            Assert.AreEqual("Test2", model.CategoriesList[1].GetMeals()[6].Name);
        }

        //新增餐點測試
        [TestMethod()]
        public void AddMealTest()
        {
            Model model = new Model();
            Meal meal = new Meal("Test", model.CategoriesList[2], 50, "/Image/meal22.png", "");
            model.AddMeal(meal);
            Assert.AreEqual("Test", model.MealsList[27].Name);
            Assert.AreEqual("Test", model.CategoriesList[2].GetMeals()[6].Name);
        }

        //刪除餐點測試
        [TestMethod()]
        public void DeleteMealTest()
        {
            Model model = new Model();
            model.DeleteMeal(5);
            Assert.AreEqual("煙燻脆雞堡", model.MealsList[5].Name);
            Assert.AreEqual(26, model.MealsList.Count);
            Assert.AreEqual("煙燻脆雞堡", model.CategoriesList[0].GetMeals()[5].Name);
            Assert.AreEqual(14, model.CategoriesList[0].GetMeals().Count);
        }

        //更新使用目前類別的餐點列表測試
        [TestMethod()]
        public void RefreshUsedListTest()
        {
            Model model = new Model();
            model.RefreshUsedList(2);
            Assert.AreEqual(6, model.MealsUsingThisCategoryList.Count);
            Assert.AreEqual("烏龍茶", model.MealsUsingThisCategoryList[5].Name);
        }

        //清除使用目前類別的餐點列表測試
        [TestMethod()]
        public void ClearUsedListTest()
        {
            Model model = new Model();
            model.RefreshUsedList(2);
            model.ClearUsedList();
            Assert.AreEqual(0, model.MealsUsingThisCategoryList.Count);
        }

        //修改類別測試
        [TestMethod()]
        public void EditCategoryTest()
        {
            Model model = new Model();
            Category category = new Category("Test");
            model.SelectMeal(6);
            model.AddOrder();
            model.EditCategory(category, 0);
            Assert.AreEqual("Test", model.CategoriesList[0].Name);
            Assert.AreEqual("Test", model.OrdersList[0].Category);
        }

        //新增類別測試
        [TestMethod()]
        public void AddCategoryTest()
        {
            Model model = new Model();
            Category category = new Category("Test");
            model.AddCategory(category);
            Assert.AreEqual(4, model.CategoriesList.Count);
            Assert.AreEqual("Test", model.CategoriesList[3].Name);
        }

        //刪除類別測試
        [TestMethod()]
        public void DeleteCategoryTest()
        {
            Model model = new Model();
            model.DeleteCategory(2);
            Assert.AreEqual(2, model.CategoriesList.Count);
            Assert.AreEqual(21, model.MealsList.Count);
        }

        //通知View變化
        [TestMethod()]
        public void NotifyObserverTest()
        {
            List<string> nameOfPropertyChanged = new List<string>();
            Model model = new Model();
            Category category = new Category("Test");
            model.ModelChanged += Test;
            model.AddCategory(category);
            Assert.AreEqual(1, observerTest);
        }

        //Function of observer test
        public void Test()
        {
            observerTest = 1;
        }
    }
}