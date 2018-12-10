namespace DrawingModel
{
    class Diamond : Shape
    {
        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        //設定位子
        public void SetLocation(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        //畫(菱形)
        public void Draw(IGraphics graphics)
        {
            graphics.DrawDiamond(_x1, _y1, _x2, _y2);
        }

        //複製
        public Shape Clone()
        {
            Diamond diamond = new Diamond();
            diamond.SetLocation(_x1, _y1, _x2, _y2);
            return diamond;
        }
    }
}
