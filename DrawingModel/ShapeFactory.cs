namespace DrawingModel
{
    public class ShapeFactory
    {
        const string ELLIPSE = "Ellipse";
        const string DIAMOND = "Diamond";
        const string LINE = "Line";
        //建立圖案
        public Shape CreateShape(string type)
        {
            if (type == ELLIPSE)
                return new Ellipse();
            else if (type == DIAMOND)
                return new Diamond();
            else if (type == LINE)
                return new Line();
            else
                return null;
        }
    }
}
