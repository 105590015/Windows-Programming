namespace DrawingModel
{
    interface Shape
    {
        //設定位子
        void SetLocation(double x1, double y1, double x2, double y2);
        //畫圖
        void Draw(IGraphics graphics);
        //複製
        Shape Clone();
    }
}
