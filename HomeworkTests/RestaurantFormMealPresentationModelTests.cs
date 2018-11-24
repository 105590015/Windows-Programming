using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class RestaurantFormMealPresentationModelTests
    {
        private Model _model;
        private RestaurantFormMealPresentationModel _restaurantFormMealPresentationModel;
        //初始化
        public void Initialize()
        {
            _model = new Model();
            _restaurantFormMealPresentationModel = new RestaurantFormMealPresentationModel(_model);
        }

        //取得model測試
        [TestMethod()]
        public void GetModelTest()
        {
            Initialize();
            Assert.AreEqual(_model, _restaurantFormMealPresentationModel.GetModel());
        }

        //取得與設定餐點名稱測試
        [TestMethod()]
        public void GetAndSetMealNameTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetMealName("");
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealName());
            _restaurantFormMealPresentationModel.SetMealName("Test");
            Assert.AreEqual("Test", _restaurantFormMealPresentationModel.GetMealName());
        }

        //取得與設定餐點單價測試
        [TestMethod()]
        public void GetAndSetMealPriceTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetMealPrice("");
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealPrice());
            _restaurantFormMealPresentationModel.SetMealPrice("Test");
            Assert.AreEqual("Test", _restaurantFormMealPresentationModel.GetMealPrice());
        }

        //取得與設定餐點類別測試
        [TestMethod()]
        public void GetAndSetMealCategoryTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetMealCategory("");
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealCategory());
            _restaurantFormMealPresentationModel.SetMealCategory("Test");
            Assert.AreEqual("Test", _restaurantFormMealPresentationModel.GetMealCategory());
        }

        //取得與設定餐點圖片位址測試
        [TestMethod()]
        public void GetAndSetMealImagePathTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetMealImagePath("");
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealImagePath());
            _restaurantFormMealPresentationModel.SetMealImagePath("Test");
            Assert.AreEqual("Test", _restaurantFormMealPresentationModel.GetMealImagePath());
        }

        //取得與設定餐點描述測試
        [TestMethod()]
        public void GetAndSetMealDescriptionTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetMealDescription("");
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealDescription());
            _restaurantFormMealPresentationModel.SetMealDescription("Test");
            Assert.AreEqual("Test", _restaurantFormMealPresentationModel.GetMealDescription());
        }

        //設定欄位狀態測試
        [TestMethod()]
        public void SetFieldEnableTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SetFieldEnable(true);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.MealNameEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.MealPriceEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.CategoryComboBoxEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.ImagePathEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.MealDescriptionEnable);
            _restaurantFormMealPresentationModel.SetFieldEnable(false);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealNameEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealPriceEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.CategoryComboBoxEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.ImagePathEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealDescriptionEnable);
        }

        //查詢並儲存餐點資料測試
        [TestMethod()]
        public void SearchMealDataTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.SearchMealData(0);
            Assert.AreEqual("大麥克", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("79", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("漢堡", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("/Image/meal01.png", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("該漢堡產品以上下兩層麵包夾住牛肉、起司、酸黃瓜、洋蔥、少量生菜、大麥克醬汁等七種食材，除了早餐外，於該餐廳全天供應。", _restaurantFormMealPresentationModel.GetMealDescription());
            _restaurantFormMealPresentationModel.SearchMealData(26);
            Assert.AreEqual("烏龍茶", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("40", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("飲料", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("/Image/meal23.png", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("烏龍派出所的警官精心沖泡而成", _restaurantFormMealPresentationModel.GetMealDescription());
        }

        //重設餐點欄位資料測試
        [TestMethod()]
        public void ResetFieldDataTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ResetFieldData();
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("漢堡", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealDescription());
            _restaurantFormMealPresentationModel.GetModel().MealsList.Clear();
            _restaurantFormMealPresentationModel.ResetFieldData();
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealCategory());
        }

        //清空餐點格子資料測試
        [TestMethod()]
        public void ClearMealDataTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ClearMealData();
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealNameEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealPriceEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.CategoryComboBoxEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.ImagePathEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.MealDescriptionEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.BrowseEnable);
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("漢堡", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealDescription());
        }

        //通知餐點相關的資料變化測試
        [TestMethod()]
        public void NotifyChangeDataOfMealTest()
        {
            List<string> nameOfPropertyChanged = new List<string>();
            Initialize();
            _restaurantFormMealPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            _restaurantFormMealPresentationModel.NotifyChangeDataOfMeal();
            Assert.AreEqual("MealGroupBoxTitle", nameOfPropertyChanged[0]);
            Assert.AreEqual("EnterMealButtonText", nameOfPropertyChanged[1]);
            Assert.AreEqual("EnterMealEnable", nameOfPropertyChanged[2]);
            Assert.AreEqual("BrowseEnable", nameOfPropertyChanged[3]);
        }

        //進入編輯餐點模式測試
        [TestMethod()]
        public void ChangeEditMealModeTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ChangeEditMealMode(1);
            Assert.AreEqual("牛肉吉士堡", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("79", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("漢堡", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("/Image/meal02.png", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("雙層澳洲純牛肉加上雙層香濃吉事，再搭配酸黃瓜、洋蔥末、蕃茄醬，通通夾在鬆軟麵包裡，這就是麥當勞經典的雙層牛肉吉事堡。", _restaurantFormMealPresentationModel.GetMealDescription());
            Assert.AreEqual("Edit Meal", _restaurantFormMealPresentationModel.MealGroupBoxTitle);
            Assert.AreEqual("Save", _restaurantFormMealPresentationModel.EnterMealButtonText);
            Assert.AreEqual(true, _model.GetComputeModel().DeleteMealEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.BrowseEnable);
        }

        //進入新增餐點模式測試
        [TestMethod()]
        public void ChangeAddMealModeTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ChangeAddMealMode();
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealName());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealPrice());
            Assert.AreEqual("漢堡", _restaurantFormMealPresentationModel.GetMealCategory());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealImagePath());
            Assert.AreEqual("", _restaurantFormMealPresentationModel.GetMealDescription());
            Assert.AreEqual("Add Meal", _restaurantFormMealPresentationModel.MealGroupBoxTitle);
            Assert.AreEqual("Add", _restaurantFormMealPresentationModel.EnterMealButtonText);
            Assert.AreEqual(false, _model.GetComputeModel().DeleteMealEnable);
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.BrowseEnable);
        }

        //儲存或新增餐點測試
        [TestMethod()]
        public void EnterMealTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ChangeEditMealMode(2);
            _restaurantFormMealPresentationModel.SetMealName("Test1");
            _restaurantFormMealPresentationModel.SetMealPrice("87");
            _restaurantFormMealPresentationModel.SetMealCategory("飲料");
            _restaurantFormMealPresentationModel.SetMealImagePath("/Image/meal23.png");
            _restaurantFormMealPresentationModel.SetMealDescription("Test2");
            _restaurantFormMealPresentationModel.EnterMeal(2);
            Assert.AreEqual("Test1", _model.MealsList[2].Name);
            Assert.AreEqual("87", _model.MealsList[2].GetPrice().ToString());
            Assert.AreEqual("飲料", _model.MealsList[2].GetCategoryName());
            Assert.AreEqual("/Image/meal23.png", _model.MealsList[2].GetImageRelativePath());
            Assert.AreEqual("Test2", _model.MealsList[2].GetDescribe());
            _restaurantFormMealPresentationModel.ChangeAddMealMode();
            _restaurantFormMealPresentationModel.SetMealName("Test3");
            _restaurantFormMealPresentationModel.SetMealPrice("987");
            _restaurantFormMealPresentationModel.SetMealCategory("套餐");
            _restaurantFormMealPresentationModel.SetMealImagePath("/Image/meal18.png");
            _restaurantFormMealPresentationModel.SetMealDescription("Test4");
            _restaurantFormMealPresentationModel.EnterMeal(-1);
            Assert.AreEqual("Test3", _model.MealsList[27].Name);
            Assert.AreEqual("987", _model.MealsList[27].GetPrice().ToString());
            Assert.AreEqual("套餐", _model.MealsList[27].GetCategoryName());
            Assert.AreEqual("/Image/meal18.png", _model.MealsList[27].GetImageRelativePath());
            Assert.AreEqual("Test4", _model.MealsList[27].GetDescribe());
            _restaurantFormMealPresentationModel.ChangeEditMealMode(0);
            _restaurantFormMealPresentationModel.SetMealImagePath("");
            _restaurantFormMealPresentationModel.EnterMeal(0);
        }

        //判斷輸入變化測試
        [TestMethod()]
        public void JudgeModifyDataTest()
        {
            Initialize();
            _restaurantFormMealPresentationModel.ChangeEditMealMode(2);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "漢堡", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("Test", "79", "漢堡", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "97", "漢堡", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "套餐", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "漢堡", "/Image/meal01.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "漢堡", "/Image/meal03.png", "Test");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("", "97", "漢堡", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "", "飲料", "/Image/meal03.png", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "漢堡", "", "Test");
            Assert.AreEqual(false, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("Test", "79", "漢堡", "/Image/meal03.png", "");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
            _restaurantFormMealPresentationModel.JudgeModifyData("勁辣雞腿堡", "79", "漢堡", "/Image/meal03.png", "");
            Assert.AreEqual(true, _restaurantFormMealPresentationModel.EnterMealEnable);
        }
    }
}