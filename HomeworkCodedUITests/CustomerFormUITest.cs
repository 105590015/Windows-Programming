using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkCodedUITests
{
    /// <summary>
    /// Summary description for CustomerFormUITest
    /// </summary>
    [CodedUITest]
    public class CustomerFormUITest
    {
        private const string FILE_PATH = @"../../../Homework/bin/Debug/Homework.exe";
        private const string STARTUP_TITLE = "StartUp";
        private const string CUSTOMER_TITLE = "POS-Customer Side";
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_TITLE);
            Robot.ClickButton("Start the Customer Program(Frontend)");
            Robot.SetForm(CUSTOMER_TITLE);
        }

        //點餐測試
        [TestMethod]
        public void OrderTest()
        {
            string[] order1 = { "X", "大麥克", "漢堡", "79元", "1", "79元" };
            string[] order2 = { "X", "辣脆雞腿堡", "漢堡", "109元", "1", "109元" };
            string[] order3 = { "X", "辣脆雞腿堡", "漢堡", "109元", "2", "218元" };
            Robot.AssertButtonEnable("Add", false);
            Robot.ClickButton("大麥克\r\n79元");
            Robot.AssertButtonEnable("Add", true);
            Robot.AssertEdit("_descriptionBox", "該漢堡產品以上下兩層麵包夾住牛肉、起司、酸黃瓜、洋蔥、少量生菜、大麥克醬汁等七種食材，除了早餐外，於該餐廳全天供應。\r");
            Robot.ClickButton("Add");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order1);
            Robot.ClickButton("辣脆雞腿堡\r\n109元");
            Robot.AssertEdit("_descriptionBox", "採用布里歐麵包、台灣在地原葉生菜、鮮採牛番茄，以及酥炸整塊無骨雞腿肉，風味獨特。\r");
            Robot.ClickButton("Add");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "2", order2);
            Robot.ClickButton("辣脆雞腿堡\r\n109元");
            Robot.ClickButton("Add");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "2", order3);
            Robot.AssertButtonEnable("Add", false);
            Robot.DeleteDataGridViewRowByIndex("_checkDataGridView", "1");
            Robot.AssertDataGridViewByIndex("_checkDataGridView", "1", order3);
            Robot.DeleteDataGridViewRowByIndex("_checkDataGridView", "0");
        }

        //換頁測試
        [TestMethod]
        public void TurnPageTest()
        {
            Robot.AssertButtonEnable("Next Page", true);
            Robot.AssertButtonEnable("Previous Page", false);
            Robot.ClickButton("Next Page");
            Robot.AssertButtonEnable("Next Page", false);
            Robot.AssertButtonEnable("Previous Page", true);
            Robot.ClickButton("安格斯黑牛堡\r\n119元");
            Robot.AssertEdit("_descriptionBox", "不僅能吃到香氣十足、鮮嫩多汁的美味牛肉，搭配香Q帶點微微鹹香的培根與生菜、番茄，感覺更加清爽順口，搭配起來一整個超合拍。\r");
            Robot.ClickButton("Previous Page");
            Robot.AssertButtonEnable("Next Page", true);
            Robot.AssertButtonEnable("Previous Page", false);
            Robot.ClickButton("千島黃金蝦堡\r\n79元");
            Robot.AssertEdit("_descriptionBox", "選用新鮮白蝦製成黃金蝦排，加上清爽蔬果千島醬和生菜，一口咬下…蝦密！真的每一口都吃得到Q彈鮮蝦。\r");
        }

        //換類別測試
        [TestMethod]
        public void ChangeCategoryTest()
        {
            Robot.ClickTabControl("套餐");
            Robot.ClickButton("卡啦雞腿堡餐\r\n109元");
            Robot.AssertEdit("_descriptionBox", "肯德基卡啦雞腿堡配上香酥脆薯條，獨家雞肉漢堡配上香酥拼盤，外送餐飲首推肯德基外送app！\r");
            Robot.AssertButtonEnable("Next Page", false);
            Robot.AssertButtonEnable("Previous Page", false);
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
