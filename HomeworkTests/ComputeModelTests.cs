using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Homework.Tests
{
    [TestClass()]
    public class ComputeModelTests
    {
        //確認餐點是否被選購測試
        [TestMethod()]
        public void CheckOrderTest()
        {
            ComputeModel computeModel = new ComputeModel();
            BindingList<Order> ordersList = new BindingList<Order>()
            {
                new Order("Test1", "漢堡", 80, 1, 80)
            };
            Category category = new Category("Category");
            Meal meal1 = new Meal("Test1", category, 80, "/Image/meal04.png", "");
            Meal meal2 = new Meal("Test2", category, 70, "/Image/meal06.png", "");
            Assert.AreEqual(true, computeModel.CheckOrder(meal1, ordersList));
            Assert.AreEqual(false, computeModel.CheckOrder(meal2, ordersList));
        }

        //取得當前頁數測試
        [TestMethod()]
        public void GetPageTest()
        {
            ComputeModel computeModel = new ComputeModel();
            Assert.AreEqual(0, computeModel.GetPage());
        }

        //換頁測試
        [TestMethod()]
        public void ChangePageTest()
        {
            ComputeModel computeModel = new ComputeModel();
            computeModel.ChangePage(11);
            Assert.AreEqual(1, computeModel.GetPage());
            computeModel.ChangePage(9);
            Assert.AreEqual(0, computeModel.GetPage());
        }

        //取得頁碼資訊測試
        [TestMethod()]
        public void GetPageInformationTest()
        {
            ComputeModel computeModel = new ComputeModel();
            Assert.AreEqual("Page：1 / 0", computeModel.GetPageInformation());
        }

        //重置頁碼測試
        [TestMethod()]
        public void ResetPageTest()
        {
            ComputeModel computeModel = new ComputeModel();
            computeModel.ResetPage(15);
            Assert.AreEqual("Page：1 / 2", computeModel.GetPageInformation());
            computeModel.ResetPage(9);
            Assert.AreEqual("Page：1 / 1", computeModel.GetPageInformation());
        }

        //控制上一頁按鈕enable測試
        [TestMethod()]
        public void ControlPreviousButtonEnableTest()
        {
            ComputeModel computeModel = new ComputeModel();
            Assert.AreEqual(false, computeModel.ControlPreviousButtonEnable());
            computeModel.ChangePage(11);
            Assert.AreEqual(true, computeModel.ControlPreviousButtonEnable());
        }

        //控制下一頁按鈕enable測試
        [TestMethod()]
        public void ControlNextButtonEnableTest()
        {
            ComputeModel computeModel = new ComputeModel();
            computeModel.ResetPage(15);
            Assert.AreEqual(true, computeModel.ControlNextButtonEnable());
            computeModel.ChangePage(11);
            Assert.AreEqual(false, computeModel.ControlNextButtonEnable());
        }

        //讀檔測試
        [TestMethod()]
        public void ReadFileTest()
        {
            ComputeModel computeModel = new ComputeModel();
            List<string> stringList = new List<string>();
            computeModel.ReadFile(stringList, "/mealsName.txt");
            Assert.AreEqual("大麥克", stringList[0]);
            Assert.AreEqual("烏龍茶", stringList[26]);
        }

        //轉換成相對位子測試
        [TestMethod()]
        public void TransformRelativePathTest()
        {
            ComputeModel computeModel = new ComputeModel();
            Assert.AreEqual("\\Image\\meal02.png", computeModel.TransformRelativePath("C:\\Users\\hjki3\\source\\repos\\105590015\\Homework\\Image\\meal02.png"));
        }

        //取得對應名稱的類別測試
        [TestMethod()]
        public void GetCategoryByNameTest()
        {
            ComputeModel computeModel = new ComputeModel();
            BindingList<Category> categories = new BindingList<Category>();
            Category category = new Category("Test");
            categories.Add(category);
            Assert.AreEqual(category, computeModel.GetCategoryByName("Test", categories));
        }

        //金額字串轉數值測試
        [TestMethod()]
        public void ChangeIntegerTest()
        {
            ComputeModel computeModel = new ComputeModel();
            Assert.AreEqual(87, computeModel.ChangeInteger("87元"));
        }

        //取得總金額測試
        [TestMethod()]
        public void GetTotalPriceTest()
        {
            ComputeModel computeModel = new ComputeModel();
            BindingList<Order> ordersList = new BindingList<Order>()
            {
                new Order("Test1", "漢堡", 80, 1, 80)
            };
            Assert.AreEqual(80, computeModel.GetTotalPrice(ordersList));
            ordersList.Add(new Order("Test2", "套餐", 90, 1, 90));
            Assert.AreEqual(170, computeModel.GetTotalPrice(ordersList));
        }

        //設定與取得商家端選擇的餐點序號測試
        [TestMethod()]
        public void SetAndGetSelectedMealOfRestaurantTest()
        {
            ComputeModel computeModel = new ComputeModel();
            computeModel.SetSelectedMealOfRestaurant(1);
            Assert.AreEqual(1, computeModel.GetSelectedMealOfRestaurant());
        }

        //設定與取得商家端選擇的餐點序號測試
        [TestMethod()]
        public void SetAndGetSelectedCategoryOfRestaurantTest()
        {
            ComputeModel computeModel = new ComputeModel();
            computeModel.SetSelectedCategoryOfRestaurant(2);
            Assert.AreEqual(2, computeModel.GetSelectedCategoryOfRestaurant());
        }

        //通知數值變化測試
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            List<string> nameOfPropertyChanged = new List<string>();
            ComputeModel computeModel = new ComputeModel();
            computeModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            computeModel.SetDeleteMealEnable(false);
            Assert.AreEqual("DeleteMealEnable", nameOfPropertyChanged[0]);
            Assert.AreEqual(1, nameOfPropertyChanged.Count);
        }
    }
}