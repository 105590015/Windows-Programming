using System.Collections.Generic;

namespace DrawingModel
{
    public class ClearCommand : ICommand
    {
        private Model _model;
        private List<Shape> _shapes = new List<Shape>();
        public ClearCommand(Model model, List<Shape> shapes)
        {
            _model = model;
            for (int i = 0; i < shapes.Count; i++)
                _shapes.Add(shapes[i]);
        }

        //清空圖案
        public void Execute()
        {
            _model.ClearShape();
        }
        //還原清空的圖案
        public void Restore()
        {
            _model.UndoClear(_shapes);
        }
    }
}
