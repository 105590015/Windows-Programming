namespace DrawingModel
{
    interface IGraphics
    {
        //清空畫面
        void ClearAll();
        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);
        //畫菱形
        void DrawDiamond(double x1, double y1, double x2, double y2);
    }
}