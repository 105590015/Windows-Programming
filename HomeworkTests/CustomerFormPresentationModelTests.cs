using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework.Tests
{
    [TestClass()]
    public class CustomerFormPresentationModelTests
    {
        private Model _model;
        private CustomerFormPresentationModel _customerFormPresentationModel;
        //初始化
        public void Initialize()
        {
            _model = new Model();
            _customerFormPresentationModel = new CustomerFormPresentationModel(_model);
        }

        //取得model測試
        [TestMethod()]
        public void GetModelTest()
        {
            Initialize();
            Assert.AreEqual(_model, _customerFormPresentationModel.GetModel());
        }

        //餐點描述欄資料測試
        [TestMethod()]
        public void GetDescriptionTextTest()
        {
            Initialize();
            _customerFormPresentationModel.ChangeMeal(0);
            Assert.AreEqual("該漢堡產品以上下兩層麵包夾住牛肉、起司、酸黃瓜、洋蔥、少量生菜、大麥克醬汁等七種食材，除了早餐外，於該餐廳全天供應。", _customerFormPresentationModel.GetDescriptionText());
            _customerFormPresentationModel.ClearMeal();
            Assert.AreEqual("", _customerFormPresentationModel.GetDescriptionText());
        }

        //重設餐點列表顯示資料測試
        [TestMethod()]
        public void RefreshButtonInformationTest()
        {
            Initialize();
            //初始狀態測試
            _customerFormPresentationModel.RefreshButtonInformation(0);
            List<string> buttonPresentationText = _customerFormPresentationModel.GetButtonPresentationText();
            List<string> buttonPresentationImagePath = _customerFormPresentationModel.GetButtonPresentationImagePath();
            List<bool> buttonVisible = _customerFormPresentationModel.GetButtonVisible();
            Assert.AreEqual("大麥克\r\n79元", buttonPresentationText[0]);
            Assert.AreEqual("牛肉吉士堡\r\n79元", buttonPresentationText[1]);
            Assert.AreEqual("勁辣雞腿堡\r\n79元", buttonPresentationText[2]);
            Assert.AreEqual("/Image/meal04.png", buttonPresentationImagePath[3]);
            Assert.AreEqual("/Image/meal05.png", buttonPresentationImagePath[4]);
            Assert.AreEqual("/Image/meal06.png", buttonPresentationImagePath[5]);
            Assert.AreEqual(true, buttonVisible[6]);
            Assert.AreEqual(true, buttonVisible[7]);
            Assert.AreEqual(true, buttonVisible[8]);
            //換頁測試
            _customerFormPresentationModel.TurnPage(11);
            _customerFormPresentationModel.RefreshButtonInformation(0);
            buttonPresentationText = _customerFormPresentationModel.GetButtonPresentationText();
            buttonPresentationImagePath = _customerFormPresentationModel.GetButtonPresentationImagePath();
            buttonVisible = _customerFormPresentationModel.GetButtonVisible();
            Assert.AreEqual("安格斯黑牛堡\r\n119元", buttonPresentationText[0]);
            Assert.AreEqual("卡啦雞腿堡\r\n79元", buttonPresentationText[3]);
            Assert.AreEqual("", buttonPresentationText[6]);
            Assert.AreEqual("/Image/meal11.png", buttonPresentationImagePath[1]);
            Assert.AreEqual("/Image/meal14.png", buttonPresentationImagePath[4]);
            Assert.AreEqual("/Image/meal01.png", buttonPresentationImagePath[7]);
            Assert.AreEqual(true, buttonVisible[2]);
            Assert.AreEqual(true, buttonVisible[5]);
            Assert.AreEqual(false, buttonVisible[8]);
            //換類別測試
            _customerFormPresentationModel.ChangeCategory(1);
            _customerFormPresentationModel.RefreshButtonInformation(1);
            buttonPresentationText = _customerFormPresentationModel.GetButtonPresentationText();
            buttonPresentationImagePath = _customerFormPresentationModel.GetButtonPresentationImagePath();
            buttonVisible = _customerFormPresentationModel.GetButtonVisible();
            Assert.AreEqual("卡啦雞腿堡餐\r\n109元", buttonPresentationText[0]);
            Assert.AreEqual("烤雞腿堡套餐\r\n109元", buttonPresentationText[1]);
            Assert.AreEqual("經典脆雞堡餐\r\n99元", buttonPresentationText[2]);
            Assert.AreEqual("/Image/meal19.png", buttonPresentationImagePath[3]);
            Assert.AreEqual("/Image/meal20.png", buttonPresentationImagePath[4]);
            Assert.AreEqual("/Image/meal21.png", buttonPresentationImagePath[5]);
            Assert.AreEqual(true, buttonVisible[0]);
            Assert.AreEqual(true, buttonVisible[3]);
            Assert.AreEqual(false, buttonVisible[6]);
        }

        //改變暫存餐點資料測試
        [TestMethod()]
        public void ChangeMealTest()
        {
            Initialize();
            //初始狀態測試
            _customerFormPresentationModel.ChangeMeal(0);
            Assert.AreEqual("該漢堡產品以上下兩層麵包夾住牛肉、起司、酸黃瓜、洋蔥、少量生菜、大麥克醬汁等七種食材，除了早餐外，於該餐廳全天供應。", _customerFormPresentationModel.GetDescriptionText());
            Assert.AreEqual(true, _customerFormPresentationModel.AddEnable);
            //換頁後測試
            _customerFormPresentationModel.TurnPage(11);
            _customerFormPresentationModel.ChangeMeal(3);
            Assert.AreEqual("肯德基卡啦雞腿堡，經典雞肉漢堡，以獨門醬料醃製，搭配上獨家技術裹粉的100%原塊卡啦雞腿肉，一口咬下，鮮嫩多汁！", _customerFormPresentationModel.GetDescriptionText());
            Assert.AreEqual(true, _customerFormPresentationModel.AddEnable);
            //換類別後測試
            _customerFormPresentationModel.ChangeCategory(2);
            _customerFormPresentationModel.ChangeMeal(5);
            Assert.AreEqual("烏龍派出所的警官精心沖泡而成", _customerFormPresentationModel.GetDescriptionText());
            Assert.AreEqual(true, _customerFormPresentationModel.AddEnable);
        }

        //清除暫存餐點資料測試
        [TestMethod()]
        public void ClearMealTest()
        {
            Initialize();
            _customerFormPresentationModel.ChangeMeal(0);
            _customerFormPresentationModel.ClearMeal();
            Assert.AreEqual("", _customerFormPresentationModel.GetDescriptionText());
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
        }

        //新增點餐測試
        [TestMethod()]
        public void AddMealTest()
        {
            Initialize();
            _customerFormPresentationModel.ChangeMeal(0);
            _customerFormPresentationModel.AddMeal();
            Assert.AreEqual(_model.MealsList[0].Name, _model.OrdersList[0].Name);
            Assert.AreEqual(_model.MealsList[0].GetCategoryName(), _model.OrdersList[0].Category);
            Assert.AreEqual(_model.MealsList[0].GetPrice().ToString() + "元", _model.OrdersList[0].Price);
            Assert.AreEqual(1, _model.OrdersList[0].Quantity);
            Assert.AreEqual(_model.MealsList[0].GetPrice().ToString() + "元", _model.OrdersList[0].Subtotal);
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
            _customerFormPresentationModel.ChangeMeal(0);
            _customerFormPresentationModel.AddMeal();
            Assert.AreEqual(_model.MealsList[0].Name, _model.OrdersList[0].Name);
            Assert.AreEqual(_model.MealsList[0].GetCategoryName(), _model.OrdersList[0].Category);
            Assert.AreEqual(_model.MealsList[0].GetPrice().ToString() + "元", _model.OrdersList[0].Price);
            Assert.AreEqual(2, _model.OrdersList[0].Quantity);
            Assert.AreEqual((_model.MealsList[0].GetPrice() * 2).ToString() + "元", _model.OrdersList[0].Subtotal);
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
        }

        //換頁測試
        [TestMethod()]
        public void TurnPageTest()
        {
            Initialize();
            Assert.AreEqual("Page：1 / 2", _model.GetComputeModel().GetPageInformation());
            Assert.AreEqual(true, _customerFormPresentationModel.NextEnable);
            Assert.AreEqual(false, _customerFormPresentationModel.PreviousEnable);
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
            _customerFormPresentationModel.TurnPage(11);
            Assert.AreEqual("Page：2 / 2", _model.GetComputeModel().GetPageInformation());
            Assert.AreEqual(false, _customerFormPresentationModel.NextEnable);
            Assert.AreEqual(true, _customerFormPresentationModel.PreviousEnable);
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
            _customerFormPresentationModel.TurnPage(9);
            Assert.AreEqual("Page：1 / 2", _model.GetComputeModel().GetPageInformation());
            Assert.AreEqual(true, _customerFormPresentationModel.NextEnable);
            Assert.AreEqual(false, _customerFormPresentationModel.PreviousEnable);
            Assert.AreEqual(false, _customerFormPresentationModel.AddEnable);
        }

        //提醒變化測試
        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {
            List<string> nameOfPropertyChanged = new List<string>();
            Initialize();
            _customerFormPresentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                nameOfPropertyChanged.Add(e.PropertyName);
            };
            _customerFormPresentationModel.ClearMeal();
            Assert.AreEqual(1, nameOfPropertyChanged.Count);
            Assert.AreEqual(nameOfPropertyChanged[0], "AddEnable");
            _customerFormPresentationModel.TurnPage(10);
            Assert.AreEqual(4, nameOfPropertyChanged.Count);
            Assert.AreEqual(nameOfPropertyChanged[1], "NextEnable");
            Assert.AreEqual(nameOfPropertyChanged[2], "PreviousEnable");
            Assert.AreEqual(nameOfPropertyChanged[3], "AddEnable");
        }
    }
}