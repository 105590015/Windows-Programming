namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        //新增圖案
        public void Execute()
        {
            _model.AddShape(_shape);
        }
        //刪除最新的圖案
        public void Restore()
        {
            _model.DeleteShape();
        }
    }
}
