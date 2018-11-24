using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homework.Tests
{
    [TestClass()]
    public class StartUpFormPresentationModelTests
    {
        private StartUpFormPresentationModel _startUpFormPresentationModel;
        //初始化
        public void Initialize()
        {
            _startUpFormPresentationModel = new StartUpFormPresentationModel();
        }

        //測試開啟客戶端按鈕狀態
        [TestMethod()]
        public void IsCustomerButtonClickedTest()
        {
            Initialize();
            Assert.AreEqual(true, _startUpFormPresentationModel.IsCustomerButtonClicked());
            _startUpFormPresentationModel.ClickCustomerButton();
            Assert.AreEqual(false, _startUpFormPresentationModel.IsCustomerButtonClicked());
            _startUpFormPresentationModel.CloseCustomerForm();
            Assert.AreEqual(true, _startUpFormPresentationModel.IsCustomerButtonClicked());
        }

        //測試開啟商家端按鈕狀態
        [TestMethod()]
        public void IsRestaurantButtonClickedTest()
        {
            Initialize();
            Assert.AreEqual(true, _startUpFormPresentationModel.IsRestaurantButtonClicked());
            _startUpFormPresentationModel.ClickRestaurantButton();
            Assert.AreEqual(false, _startUpFormPresentationModel.IsRestaurantButtonClicked());
            _startUpFormPresentationModel.CloseRestaurantForm();
            Assert.AreEqual(true, _startUpFormPresentationModel.IsRestaurantButtonClicked());
        }
    }
}
