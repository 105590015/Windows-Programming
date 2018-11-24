using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class RestaurantFormCategoryPresentationModelTests
    {
        private Model _model;
        private RestaurantFormCategoryPresentationModel _restaurantFormCategoryPresentationModel;
        //初始化
        public void Initialize()
        {
            _model = new Model();
            _restaurantFormCategoryPresentationModel = new RestaurantFormCategoryPresentationModel(_model);
        }

        //取得Model測試
        [TestMethod()]
        public void GetModelTest()
        {
            Initialize();
            Assert.AreEqual(_model, _restaurantFormCategoryPresentationModel.GetModel());
        }

        //取得與設定類別名稱資料
        [TestMethod()]
        public void GetAndSetCategoryNameTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.SetCategoryName("Test");
            Assert.AreEqual("Test", _restaurantFormCategoryPresentationModel.GetCategoryName());
        }

        //設定類別欄位enable
        [TestMethod()]
        public void SetFieldEnableTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.SetFieldEnable(true);
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.CategoryNameEnable);
            _restaurantFormCategoryPresentationModel.SetFieldEnable(false);
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.CategoryNameEnable);
        }

        //清空類別格子資料
        [TestMethod()]
        public void ClearCategoryDataTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.ClearCategoryData();
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.CategoryNameEnable);
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().DeleteCategoryEnable);
            Assert.AreEqual("", _restaurantFormCategoryPresentationModel.GetCategoryName());
            Assert.AreEqual(0, _model.MealsUsingThisCategoryList.Count);
        }

        //通知類別相關的資料變化測試
        [TestMethod()]
        public void NotifyChangeDataOfCategoryTest()
        {
            List<string> nameOfPropertyChanged = new List<string>();
            Initialize();
            _restaurantFormCategoryPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            _restaurantFormCategoryPresentationModel.NotifyChangeDataOfCategory();
            Assert.AreEqual("CategoryGroupBoxTitle", nameOfPropertyChanged[0]);
            Assert.AreEqual("EnterCategoryButtonText", nameOfPropertyChanged[1]);
            Assert.AreEqual("EnterCategoryEnable", nameOfPropertyChanged[2]);
        }

        //改成編輯類別模式
        [TestMethod()]
        public void ChangeEditCategoryModeTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.ChangeEditCategoryMode(0);
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.CategoryNameEnable);
            Assert.AreEqual("Edit Category", _restaurantFormCategoryPresentationModel.CategoryGroupBoxTitle);
            Assert.AreEqual("Save", _restaurantFormCategoryPresentationModel.EnterCategoryButtonText);
            Assert.AreEqual("大麥克", _model.MealsUsingThisCategoryList[0].Name);
            Assert.AreEqual("經典脆雞堡", _model.MealsUsingThisCategoryList[14].Name);
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().DeleteCategoryEnable);
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
            Assert.AreEqual("漢堡", _restaurantFormCategoryPresentationModel.GetCategoryName());
        }

        //改成新增類別模式測試
        [TestMethod()]
        public void ChangeAddCategoryModeTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.ChangeAddCategoryMode();
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.CategoryNameEnable);
            Assert.AreEqual("Add Category", _restaurantFormCategoryPresentationModel.CategoryGroupBoxTitle);
            Assert.AreEqual("Add", _restaurantFormCategoryPresentationModel.EnterCategoryButtonText);
            Assert.AreEqual(0, _model.MealsUsingThisCategoryList.Count);
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
            Assert.AreEqual("", _restaurantFormCategoryPresentationModel.GetCategoryName());
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().DeleteCategoryEnable);
        }

        //儲存或新增類別測試
        [TestMethod()]
        public void EnterCategoryTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.ChangeEditCategoryMode(1);
            _restaurantFormCategoryPresentationModel.SetCategoryName("Test1");
            _restaurantFormCategoryPresentationModel.EnterCategory(1);
            Assert.AreEqual("Test1", _model.CategoriesList[1].Name);
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().DeleteCategoryEnable);
            _restaurantFormCategoryPresentationModel.ChangeAddCategoryMode();
            _restaurantFormCategoryPresentationModel.SetCategoryName("Test2");
            _restaurantFormCategoryPresentationModel.EnterCategory(-1);
            Assert.AreEqual("Test2", _model.CategoriesList[3].Name);
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.GetModel().GetComputeModel().DeleteCategoryEnable);
        }

        //判斷是否修改類別數值測試
        [TestMethod()]
        public void JudgeModifyDataTest()
        {
            Initialize();
            _restaurantFormCategoryPresentationModel.ChangeEditCategoryMode(1);
            _restaurantFormCategoryPresentationModel.JudgeModifyData("Test");
            Assert.AreEqual(true, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
            _restaurantFormCategoryPresentationModel.JudgeModifyData("");
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
            _restaurantFormCategoryPresentationModel.JudgeModifyData("套餐");
            Assert.AreEqual(false, _restaurantFormCategoryPresentationModel.EnterCategoryEnable);
        }
    }
}