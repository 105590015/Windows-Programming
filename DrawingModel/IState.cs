namespace DrawingModel
{
    public interface IState
    {
        //點擊鼠標
        Shape PressPointer(double locationX, double locationY);
        //移動鼠標
        Shape MovePointer(double locationX, double locationY);
        //放開鼠標
        void ReleasePointer(double locationX, double locationY);
    }
}
