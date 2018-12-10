using System.Drawing;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
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
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫菱形
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            const int TWO = 2;
            PointF top = new PointF(((float)x1 + (float)x2) / TWO, (float)y1);
            PointF right = new PointF((float)x2, ((float)y1 + (float)y2) / TWO);
            PointF bottom = new PointF(((float)x1 + (float)x2) / TWO, (float)y2);
            PointF left = new PointF((float)x1, ((float)y1 + (float)y2) / TWO);
            PointF[] points = { top, right, bottom, left };
            _graphics.FillPolygon(Brushes.Yellow, points);
            _graphics.DrawPolygon(Pens.Black, points);
        }
    }
}
