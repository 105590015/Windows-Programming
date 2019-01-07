using System.Collections.Generic;

namespace DrawingModel
{
    public class Ellipse : Shape
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

        //畫(橢圓)
        public void Draw(IGraphics graphics)
        {
            List<double> point1 = new List<double>()
            { 
                _x1, _y1 };
            List<double> point2 = new List<double>()
            { 
                _x2, _y2 };
            graphics.DrawEllipse(point1, point2, _isChosen);
        }

        //複製
        public Shape Clone(bool isChosen)
        {
            Ellipse ellipses = new Ellipse();
            ellipses.SetLocation(_x1, _y1, _x2, _y2);
            ellipses.SetChosen(isChosen);
            return ellipses;
        }

        //是否被點擊
        public bool IsClicked(double locationX, double locationY)
        {
            const int TWO = 2;
            const double ONE = 1.0;
            double xRadius = System.Math.Abs(_x2 - _x1) / TWO;
            double yRadius = System.Math.Abs(_y2 - _y1) / TWO;
            double xCenter = _x1 + xRadius;
            double yCenter = _y1 + yRadius;
            double xMinus = locationX - xCenter;
            double yMinus = locationY - yCenter;
            double distance = ((xMinus * xMinus) / (xRadius * xRadius)) + ((yMinus * yMinus) / (yRadius * yRadius));
            return distance <= ONE;
        }

        //設定選取
        public void SetChosen(bool isChosen)
        {
            _isChosen = isChosen;
        }

        //取得字串型態的資訊
        public string GetInformation()
        {
            const string ELLIPSE = "Ellipse,";
            const string COMMA = ",";
            return ELLIPSE + _x1.ToString() + COMMA + _y1.ToString() + COMMA + _x2.ToString() + COMMA + _y2.ToString();
        }
    }
}
