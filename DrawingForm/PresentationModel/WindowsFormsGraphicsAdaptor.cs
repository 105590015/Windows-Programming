using System.Drawing;
using System.Collections.Generic;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除圖畫
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //畫線
        public void DrawLine(List<double> point1, List<double> point2, bool isChosen)
        {
            if (isChosen)
                _graphics.DrawLine(Pens.Red, (float)point1[0], (float)point1[1], (float)point2[0], (float)point2[1]);
            else
                _graphics.DrawLine(Pens.Black, (float)point1[0], (float)point1[1], (float)point2[0], (float)point2[1]);
        }

        //畫菱形
        public void DrawDiamond(List<double> point1, List<double> point2, bool isChosen)
        {
            const int TWO = 2;
            PointF top = new PointF(((float)point1[0] + (float)point2[0]) / TWO, (float)point1[1]);
            PointF right = new PointF((float)point2[0], ((float)point1[1] + (float)point2[1]) / TWO);
            PointF bottom = new PointF(((float)point1[0] + (float)point2[0]) / TWO, (float)point2[1]);
            PointF left = new PointF((float)point1[0], ((float)point1[1] + (float)point2[1]) / TWO);
            PointF[] points = { top, right, bottom, left };
            _graphics.FillPolygon(Brushes.Yellow, points);
            if (isChosen)
                _graphics.DrawPolygon(Pens.Red, points);
            else
                _graphics.DrawPolygon(Pens.Black, points);
        }

        //畫橢圓
        public void DrawEllipse(List<double> point1, List<double> point2, bool isChosen)
        {
            double width = point2[0] - point1[0];
            double height = point2[1] - point1[1];
            RectangleF rectangle = new RectangleF((float)point1[0], (float)point1[1], (float)width, (float)height);
            _graphics.FillEllipse(Brushes.Yellow, rectangle);
            if (isChosen)
                _graphics.DrawEllipse(Pens.Red, rectangle);
            else
                _graphics.DrawEllipse(Pens.Black, rectangle);
        }
    }
}
