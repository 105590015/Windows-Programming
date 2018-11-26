using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkCodedUITests
{
    /// <summary>
    /// Summary description for IntegrateUITest
    /// </summary>
    [CodedUITest]
    public class IntegrateUITest
    {
        private const string FILE_PATH = @"../../../Homework/bin/Debug/Homework.exe";
        private const string STARTUP_TITLE = "StartUp";
        private const string CUSTOMER_TITLE = "POS-Customer Side";
        private const string RESTAURANT_TITLE = "POS-Restaurant Side";
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_TITLE);
            Robot.ClickButton("Start the Customer Program(Frontend)");
            Robot.ClickButton("Start the Restaurant Program(Backend)");
        }

        //更新餐點
        [TestMethod]
        public void UpdateMealTest()
        {
            string[] order1 = { "X", "小麥克", "漢堡", "69元", "1", "69元" };
            string[] order2 = { "X", "小麥克", "飲料", "69元", "2", "138元" };
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickButton("大麥克\r\n79元");
            Robot.ClickButton("Add");
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "大麥克\r");
            Robot.SetEdit("_mealNameTextBox", "小麥克");
            Robot.SendKeyEnterToMessageBox(RESTAURANT_TITLE);
            Robot.SetEdit("_mealPriceTextBox", "69");
            Robot.SetEdit("_imagePathTextBox", "/Image/meal23.png");
            Robot.SetEdit("_mealDescriptionTextBox", "It is a test");
            Robot.ClickButton("Save");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickButton("小麥克\r\n69元");
            Robot.AssertEdit("_descriptionBox", "It is a test\r");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order1);
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.SetComboBox("_categoryComboBox", "飲料");
            Robot.ClickButton("Save");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickTabControl("飲料");
            Robot.ClickButton("小麥克\n69元");
            Robot.ClickButton("Add");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order2);
        }

        //新增餐點
        [TestMethod]
        public void AddMealTest()
        {
            string[] order = { "X", "Test", "套餐", "66元", "1", "66元" };
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "Test");
            Robot.SetEdit("_mealPriceTextBox", "66");
            Robot.SetComboBox("_categoryComboBox", "套餐");
            Robot.SetEdit("_imagePathTextBox", "/Image/meal16.png");
            Robot.SetEdit("_mealDescriptionTextBox", "It is a test");
            Robot.ClickButton("Add");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickTabControl("套餐");
            Robot.ClickButton("Test\n66元");
            Robot.AssertEdit("_descriptionBox", "It is a test\r");
            Robot.ClickButton("Add\r");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order);
        }

        //刪除餐點
        [TestMethod]
        public void DeleteMealTest()
        {
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickButton("起司脆薯牛堡\r\n99元");
            Robot.ClickButton("Add");
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "起司脆薯牛堡");
            Robot.AssertButtonEnable("Delete Selected Meal", false);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "安格斯黑牛堡");
            Robot.ClickButton("Delete Selected Meal");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "麥香雞");
            Robot.ClickButton("Delete Selected Meal");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "麥香魚");
            Robot.ClickButton("Delete Selected Meal");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "卡啦雞腿堡");
            Robot.ClickButton("Delete Selected Meal");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "烤雞腿堡");
            Robot.ClickButton("Delete Selected Meal");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "經典脆雞堡");
            Robot.ClickButton("Delete Selected Meal");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.AssertText("_pageLabel", "Page：1 / 1");
        }

        //更新類別
        [TestMethod]
        public void UpdateCategoryTest()
        {
            string[] order = { "X", "烤雞腿堡套餐", "Test", "109元", "1", "109元" };
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickTabControl("套餐");
            Robot.ClickButton("烤雞腿堡套餐\r\n109元");
            Robot.ClickButton("Add");
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickTabControl("Category Manager");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "套餐");
            Robot.SetEdit("_categoryNameTextBox", "Test");
            Robot.ClickButton("Save");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order);
            Robot.ClickTabControl("Test");
            Robot.ClickButton("烤雞腿堡套餐\r\n109元");
            Robot.AssertEdit("_descriptionBox", "肯德基紐奧良烤雞腿堡搭配金黃脆薯，讓你美味聚餐不設限！\r");
        }

        //新增類別
        [TestMethod]
        public void AddCategoryTest()
        {
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickTabControl("Category Manager");
            Robot.ClickButton("Add New Category");
            Robot.SetEdit("_categoryNameTextBox", "Test");
            Robot.ClickButton("Add");
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickTabControl("Test");
            Robot.AssertButtonEnable("Add", false);
        }

        //刪除類別
        [TestMethod]
        public void DeleteCategoryTest()
        {
            Robot.SetForm(CUSTOMER_TITLE);
            Robot.ClickButton("辣脆雞腿堡\r\n109元");
            Robot.ClickButton("Add");
            Robot.SetForm(RESTAURANT_TITLE);
            Robot.ClickTabControl("Category Manager");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "漢堡");
            Robot.AssertButtonEnable("Delete Selected Category", false);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }
    }
}
