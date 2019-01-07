using System.Collections.Generic;

namespace DrawingModel
{
    public class CommandManager
    {
        private Stack<ICommand> _undo = new Stack<ICommand>();
        private Stack<ICommand> _redo = new Stack<ICommand>();

        //上一步按鈕狀態
        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }

        //下一步按鈕狀態
        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        //執行命令
        public void Execute(ICommand command)
        {
            _undo.Push(command);
            _redo.Clear();
            command.Execute();
        }
        //上一步
        public void Undo()
        {
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.Restore();
        }
        //下一步
        public void Redo()
        {
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        //重設
        public void Reset()
        {
            _undo.Clear();
            _redo.Clear();
        }
    }
}
