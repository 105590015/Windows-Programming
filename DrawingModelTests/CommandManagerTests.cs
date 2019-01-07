using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        //執行命令測試
        [TestMethod()]
        public void ExecuteTest()
        {
            Model model = new Model("", "", "", false);
            CommandManager commandManager = new CommandManager();
            commandManager.Execute(new ClearCommand(model, new List<Shape>()));
            Assert.AreEqual(commandManager.IsUndoEnabled, true);
            Assert.AreEqual(commandManager.IsRedoEnabled, false);
        }

        //上一步測試
        [TestMethod()]
        public void UndoTest()
        {
            Model model = new Model("", "", "", false);
            CommandManager commandManager = new CommandManager();
            commandManager.Execute(new ClearCommand(model, new List<Shape>()));
            commandManager.Undo();
            Assert.AreEqual(commandManager.IsUndoEnabled, false);
            Assert.AreEqual(commandManager.IsRedoEnabled, true);
        }

        //下一步測試
        [TestMethod()]
        public void RedoTest()
        {
            Model model = new Model("", "", "", false);
            CommandManager commandManager = new CommandManager();
            commandManager.Execute(new ClearCommand(model, new List<Shape>()));
            commandManager.Undo();
            commandManager.Redo();
            Assert.AreEqual(commandManager.IsUndoEnabled, true);
            Assert.AreEqual(commandManager.IsRedoEnabled, false);
        }

        //重設測試
        [TestMethod()]
        public void ResetTest()
        {
            Model model = new Model("", "", "", false);
            CommandManager commandManager = new CommandManager();
            commandManager.Execute(new ClearCommand(model, new List<Shape>()));
            commandManager.Reset();
            Assert.AreEqual(commandManager.IsUndoEnabled, false);
            Assert.AreEqual(commandManager.IsRedoEnabled, false);
        }
    }
}