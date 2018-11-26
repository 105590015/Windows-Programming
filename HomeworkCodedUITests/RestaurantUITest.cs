using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkCodedUITests
{
    /// <summary>
    /// Summary description for RestaurantUITest
    /// </summary>
    [CodedUITest]
    public class RestaurantUITest
    {
        private const string FILE_PATH = @"../../../Homework/bin/Debug/Homework.exe";
        private const string STARTUP_TITLE = "StartUp";
        private const string RESTAURANT_TITLE = "POS-Restaurant Side";
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_TITLE);
            Robot.ClickButton("Start the Restaurant Program(Backend)");
            Robot.SetForm(RESTAURANT_TITLE);
        }

        //餐點編輯測試
        [TestMethod]
        public void EditMealTest()
        {
            string[] path = { "Image", "meal04" };
            Robot.AssertButtonEnable("Browse", false);
            Robot.AssertButtonEnable("Save", false);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "勁辣雞腿堡\r");
            Robot.AssertEdit("_mealNameTextBox", "勁辣雞腿堡");
            Robot.AssertEdit("_mealPriceTextBox", "79");
            Robot.AssertComboBox("_categoryComboBox", "漢堡");
            Robot.AssertEdit("_imagePathTextBox", "/Image/meal03.png");
            Robot.AssertButtonEnable("Browse", true);
            Robot.AssertEdit("_mealDescriptionTextBox", "新鮮萵苣加上完全不施打生長激素的健康雞，以及一級小麥粉特製麵包，健康美味。");
            Robot.AssertButtonEnable("Save", false);
            Robot.SetEdit("_mealNameTextBox", "Test");
            Robot.AssertButtonEnable("Save", true);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "起司豬排堡\r");
            Robot.SetEdit("_mealPriceTextBox", "999");
            Robot.AssertButtonEnable("Save", true);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "煙燻脆雞堡\r");
            Robot.SetComboBox("_categoryComboBox", "套餐");
            Robot.AssertButtonEnable("Save", true);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "嫩煎雞腿堡\r");
            Robot.SetEdit("_imagePathTextBox", "Test");
            Robot.ClickButton("Save");
            Robot.SendKeyEnterToMessageBox("輸入錯誤");
            Robot.ClickButton("Browse");
            Robot.CloseWindow("開啟");
            Robot.ClickButton("Browse");
            Robot.SelectFileByOpenFileDialog("開啟", path);
            Robot.ClickButton("Save");
        }

        //餐點新增測試
        [TestMethod]
        public void AddMealTest()
        {
            Robot.ClickButton("Add New Meal");
            Robot.SetEdit("_mealNameTextBox", "Test");
            Robot.SetEdit("_mealPriceTextBox", "1");
            Robot.SetComboBox("_categoryComboBox", "漢堡");
            Robot.SetEdit("_imagePathTextBox", "/Image/meal01.png");
            Robot.SetEdit("_mealDescriptionTextBox", "It is a Test");
            Robot.ClickButton("Add");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "經典脆雞堡\r");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "Test\r");
            Robot.AssertEdit("_mealNameTextBox", "Test");
            Robot.AssertEdit("_mealPriceTextBox", "1");
            Robot.AssertComboBox("_categoryComboBox", "漢堡");
            Robot.AssertEdit("_imagePathTextBox", "/Image/meal01.png");
            Robot.AssertEdit("_mealDescriptionTextBox", "It is a Test");
        }

        //餐點刪除測試
        [TestMethod]
        public void DeleteMealTest()
        {
            Robot.AssertButtonEnable("Delete Selected Meal", false);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "麥香魚\r");
            Robot.AssertButtonEnable("Delete Selected Meal", true);
            Robot.ClickButton("Delete Selected Meal");
        }

        //類別編輯測試
        [TestMethod]
        public void EditCategoryTest()
        {
            Robot.ClickTabControl("Category Manager");
            Robot.AssertButtonEnable("Save", false);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "漢堡\r");
            Robot.SetEdit("_categoryNameTextBox", "Test");
            Robot.AssertButtonEnable("Save", true);
            Robot.ClickButton("Save");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "飲料\r");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "Test\r");
            Robot.AssertEdit("_categoryNameTextBox", "Test");
        }

        //類別新增測試
        [TestMethod]
        public void AddCategoryTest()
        {
            Robot.ClickTabControl("Category Manager");
            Robot.ClickButton("Add New Category");
            Robot.SetEdit("_categoryNameTextBox", "Test");
            Robot.ClickButton("Add");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "Test\r");
            Robot.AssertEdit("_categoryNameTextBox", "Test");
        }

        //類別刪除測試
        [TestMethod]
        public void DeleteCategoryTest()
        {
            Robot.ClickTabControl("Category Manager");
            Robot.AssertButtonEnable("Delete Selected Category", false);
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "漢堡\r");
            Robot.AssertButtonEnable("Delete Selected Category", true);
            Robot.ClickButton("Delete Selected Category");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "套餐\r");
            Robot.ClickButton("Delete Selected Category");
            Robot.ClickListViewByValue(RESTAURANT_TITLE, "飲料\r");
            Robot.ClickButton("Delete Selected Category");
            Robot.ClickTabControl("Meal Manager");
            Robot.AssertComboBox("_categoryComboBox", null);
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
