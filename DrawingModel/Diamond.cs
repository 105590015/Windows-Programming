using System.Collections.Generic;

namespace DrawingModel
{
    public class Diamond : Shape
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private bool _isChosen = false;
        //設定位子
        public void SetLocation(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        //移動位子
        public void MoveLocation(double xMove, double yMove)
        {
            _x1 += xMove;
            _y1 += yMove;
            _x2 += xMove;
            _y2 += yMove;
        }

        //畫(菱形)
        public void Draw(IGraphics graphics)
        {
            List<double> point1 = new List<double>()
            { 
                _x1, _y1 };
            List<double> point2 = new List<double>()
            { 
                _x2, _y2 };
            graphics.DrawDiamond(point1, point2, _isChosen);
        }

        //複製
        public Shape Clone(bool isChosen)
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(_x1, _y1, _x2, _y2);
            diamond.SetChosen(isChosen);
            return diamond;
        }

        //是否被點擊
        public bool IsClicked(double locationX, double locationY)
        {
            const int TWO = 2;
            const int FOUR = 4;
            double width = System.Math.Abs(_x2 - _x1);
            double height = System.Math.Abs(_y2 - _y1);
            double centerX = _x1 + width / TWO;
            double centerY = _y1 + height / TWO;
            double tempX = System.Math.Abs(centerX - locationX);
            double tempY = System.Math.Abs(centerY - locationY);
            return (tempX * height / TWO) + (tempY * width / TWO) <= width * height / FOUR;
        }

        //設定選取
        public void SetChosen(bool isChosen)
        {
            _isChosen = isChosen;
        }

        //取得字串型態的資訊
        public string GetInformation()
        {
            const string DIAMOND = "Diamond,";
            const string COMMA = ",";
            return DIAMOND + _x1.ToString() + COMMA + _y1.ToString() + COMMA + _x2.ToString() + COMMA + _y2.ToString();
        }
    }
}
