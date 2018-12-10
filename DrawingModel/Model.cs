using System.Collections.Generic;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed = false;
        private List<Shape> _shapes = new List<Shape>();
        private Shape _hint;
        //設定圖形
        public void SetShape(Shape shape)
        {
            _hint = shape;
        }

        //當鼠標點擊，紀錄點擊位子
        public void PressPointer(double locationX, double locationY)
        {
            if (locationX > 0 && locationY > 0)
            {
                _firstPointX = locationX;
                _firstPointY = locationY;
                _isPressed = true;
            }
        }

        //更新(按壓著時)鼠標移動的位子
        public void MovePointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                _hint.SetLocation(_firstPointX, _firstPointY, locationX, locationY);
                NotifyModelChanged();
            }
        }

        //放開滑鼠，進行畫圖
        public void ReleasePointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _hint.SetLocation(_firstPointX, _firstPointY, locationX, locationY);
                Shape shape = _hint.Clone();
                _shapes.Add(shape);
                NotifyModelChanged();
            }
        }

        //清除圖畫
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        //通知數值變化
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged.Invoke();
        }
    }
}
