using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
    {
        private Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        //清除圖畫
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //畫菱形
        public void DrawDiamond(double x1, double y1, double x2, double y2)
        {
            const int TWO = 2;
            Windows.UI.Xaml.Shapes.Polygon diamond = new Windows.UI.Xaml.Shapes.Polygon();
            diamond.Points.Add(new Point((x1 + x2) / TWO, y1));
            diamond.Points.Add(new Point(x2, (y1 + y2) / TWO));
            diamond.Points.Add(new Point((x1 + x2) / TWO, y2));
            diamond.Points.Add(new Point(x1, (y1 + y2) / TWO));
            diamond.Fill = new SolidColorBrush(Colors.Yellow);
            diamond.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(diamond);
        }
    }
}