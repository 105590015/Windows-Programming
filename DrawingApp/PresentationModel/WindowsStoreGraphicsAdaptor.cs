using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using DrawingModel;
using System.Collections.Generic;

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
        public void DrawLine(List<double> point1, List<double> point2, bool isChosen)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line()
            { 
                X1 = point1[0],
                Y1 = point1[1],
                X2 = point2[0],
                Y2 = point2[1] };
            if (isChosen)
                line.Stroke = new SolidColorBrush(Colors.Red);
            else
                line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        //畫菱形
        public void DrawDiamond(List<double> point1, List<double> point2, bool isChosen)
        {
            const int TWO = 2;
            Windows.UI.Xaml.Shapes.Polygon diamond = new Windows.UI.Xaml.Shapes.Polygon()
            { 
                Fill = new SolidColorBrush(Colors.Yellow) };
            diamond.Points.Add(new Point((point1[0] + point2[0]) / TWO, point1[1]));
            diamond.Points.Add(new Point(point2[0], (point1[1] + point2[1]) / TWO));
            diamond.Points.Add(new Point((point1[0] + point2[0]) / TWO, point2[1]));
            diamond.Points.Add(new Point(point1[0], (point1[1] + point2[1]) / TWO));
            if (isChosen)
                diamond.Stroke = new SolidColorBrush(Colors.Red);
            else
                diamond.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(diamond);
        }

        //畫橢圓
        public void DrawEllipse(List<double> point1, List<double> point2, bool isChosen)
        {
            List<double> margin = ComputeMargin(point1[0], point1[1], point2[0], point2[1]);
            Windows.UI.Xaml.Shapes.Ellipse ellipse = new Windows.UI.Xaml.Shapes.Ellipse()
            { 
                Width = System.Math.Abs(point2[0] - point1[0]),
                Height = System.Math.Abs(point2[1] - point1[1]),
                Margin = new Windows.UI.Xaml.Thickness(margin[0], margin[1], 0, 0),
                Fill = new SolidColorBrush(Colors.Yellow) };
            if (isChosen)
                ellipse.Stroke = new SolidColorBrush(Colors.Red);
            else
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(ellipse);
        }

        //計算橢圓參數
        public List<double> ComputeMargin(double x1, double y1, double x2, double y2)
        {
            List<double> margin = new List<double>();
            if (x2 > x1)
                margin.Add(x1);
            else
                margin.Add(x2);
            if (y2 > y1)
                margin.Add(y1);
            else
                margin.Add(y2);
            return margin;
        }
    }
}