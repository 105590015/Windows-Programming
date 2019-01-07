namespace DrawingModel
{
    public class MoveCommand : ICommand
    {
        private Model _model;
        private Shape _newShape;
        private Shape _originShape;
        private int _index;
        public MoveCommand(Model model, Shape newShape, Shape originShape, int index)
        {
            _model = model;
            _newShape = newShape;
            _originShape = originShape;
            _index = index;
        }

        //移動圖案
        public void Execute()
        {
            _model.UpdateShape(_newShape, _index);
        }
        //還原移動的圖案
        public void Restore()
        {
            _model.UpdateShape(_originShape, _index);
        }
    }
}
