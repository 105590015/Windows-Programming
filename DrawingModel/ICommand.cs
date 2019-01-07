namespace DrawingModel
{
    public interface ICommand
    {
        //執行命令
        void Execute();
        //還原命令
        void Restore();
    }
}
