namespace DrawingModel
{
    public interface Shape
    {
        //設定位子
        void SetLocation(double x1, double y1, double x2, double y2);
        //移動位子
        void MoveLocation(double xMove, double yMove);
        //畫圖
        void Draw(IGraphics graphics);
        //複製
        Shape Clone(bool isChosen);
        //是否被點擊
        bool IsClicked(double locationX, double locationY);
        //設定選取
        void SetChosen(bool isChosen);
        //取得字串型態的資訊
        string GetInformation();
    }
}
