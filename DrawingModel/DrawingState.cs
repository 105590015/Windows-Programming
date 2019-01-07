namespace DrawingModel
{
    public class DrawingState : IState
    {
        private Model _model;
        private CommandManager _commandManager;
        private Shape _hint;
        private double _firstPointX;
        private double _firstPointY;
        public DrawingState(Model model, CommandManager commandManager, Shape shape)
        {
            _model = model;
            _commandManager = commandManager;
            _hint = shape;
        }

        //當鼠標點擊，紀錄點擊位子
        public Shape PressPointer(double locationX, double locationY)
        {
            _firstPointX = locationX;
            _firstPointY = locationY;
            return _hint;
        }

        //更新(按壓著時)鼠標移動的位子
        public Shape MovePointer(double locationX, double locationY)
        {
            _hint.SetLocation(_firstPointX, _firstPointY, locationX, locationY);
            return _hint;
        }

        //放開滑鼠，進行畫圖
        public void ReleasePointer(double locationX, double locationY)
        {
            _hint.SetLocation(_firstPointX, _firstPointY, locationX, locationY);
            Shape shape = _hint.Clone(false);
            _commandManager.Execute(new DrawCommand(_model, shape));
        }
    }
}
