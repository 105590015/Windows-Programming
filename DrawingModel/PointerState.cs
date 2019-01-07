using System.Collections.Generic;

namespace DrawingModel
{
    public class PointerState : IState
    {
        private Model _model;
        private CommandManager _commandManager;
        private List<Shape> _shapes;
        private Shape _hint;
        private Shape _originShape;
        private double _firstPointX;
        private double _firstPointY;
        private int _index;
        public PointerState(Model model, CommandManager commandManager, List<Shape> shapes)
        {
            _model = model;
            _commandManager = commandManager;
            _shapes = shapes;
        }

        //當鼠標點擊，判斷是不是點擊形狀
        public Shape PressPointer(double locationX, double locationY)
        {
            _firstPointX = locationX;
            _firstPointY = locationY;
            for (int i = _shapes.Count - 1; i > -1; i--)
            { 
                if (_shapes[i].IsClicked(locationX, locationY))
                {
                    _index = i;
                    _originShape = _shapes[i];
                    _hint = _shapes[i].Clone(true);
                    _shapes[i] = null;
                }
                else
                    _shapes[i].SetChosen(false);
            }
            return _hint;
        }

        //更新(按壓著時)鼠標移動的位子
        public Shape MovePointer(double locationX, double locationY)
        {
            if (_hint != null)
            {
                _hint.MoveLocation(locationX - _firstPointX, locationY - _firstPointY);
                _firstPointX = locationX;
                _firstPointY = locationY;
                return _hint;
            }
            return null;
        }

        //放開滑鼠，進行畫圖
        public void ReleasePointer(double locationX, double locationY)
        {
            if (_hint != null)
            {
                Shape shape = _hint.Clone(true);
                _commandManager.Execute(new MoveCommand(_model, shape, _originShape, _index));
            }
        }
    }
}
