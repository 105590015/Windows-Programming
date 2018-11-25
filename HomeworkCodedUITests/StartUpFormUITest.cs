using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkCodedUITests
{
    /// <summary>
    /// Summary description for MainFormUITest
    /// </summary>
    [CodedUITest]
    public class StartUpFormUITest
    {
        private const string FILE_PATH = @"../../../Homework/bin/Debug/Homework.exe";
        private const string STARTUP_TITLE = "StartUp";
        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, STARTUP_TITLE);
        }

        //開啟客戶端程式測試
        [TestMethod]
        public void TestOpenCustomerForm()
        {
            Robot.ClickButton("Start the Customer Program(Frontend)");
            Robot.AssertButtonEnable("Start the Customer Program(Frontend)", false);
            Robot.CloseWindow("POS-Customer Side");
            Robot.AssertButtonEnable("Start the Customer Program(Frontend)", true);
        }


        //開啟商家端程式測試
        [TestMethod]
        public void TestOpenRestaurantForm()
        {
            Robot.ClickButton("Start the Restaurant Program(Backend)");
            Robot.AssertButtonEnable("Start the Restaurant Program(Backend)", false);
            Robot.CloseWindow("POS-Restaurant Side");
            Robot.AssertButtonEnable("Start the Restaurant Program(Backend)", true);
        }

        //關閉程式測試
        [TestMethod]
        public void TestExit()
        {
            Robot.ClickButton("Exit");
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