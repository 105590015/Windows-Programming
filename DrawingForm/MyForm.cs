using System;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class MyForm : Form
    {
        private DrawingModel.Model _model;
        private PresentationModel.PresentationModel _presentationModel;
        const string ENABLE = "Enabled";
        public MyForm()
        {
            InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model.SetShape(new DrawingModel.Line());
            _model._modelChanged += HandleModelChanged;
            _canvas.MouseDown += PressCanvas;
            _canvas.MouseUp += ReleaseCanvas;
            _canvas.MouseMove += MoveCanvas;
            _canvas.Paint += PaintCanvas;
            _diamondButton.Click += DrawDiamond;
            _lineButton.Click += DrawLine;
            _clearButton.Click += ClearPanel;
            _lineButton.DataBindings.Add(ENABLE, _presentationModel, "LineButtonEnable");
            _diamondButton.DataBindings.Add(ENABLE, _presentationModel, "DiamondButtonEnable");
        }
        //菱形模式
        public void DrawDiamond(object sender, EventArgs e)
        {
            _model.SetShape(new DrawingModel.Diamond());
            _presentationModel.ClickDiamondButton();
        }

        //直線模式
        public void DrawLine(object sender, EventArgs e)
        {
            _model.SetShape(new DrawingModel.Line());
            _presentationModel.ClickLineButton();
        }

        //清除畫面
        public void ClearPanel(object sender, EventArgs e)
        {
            _model.Clear();
        }

        //滑鼠點擊畫布,紀錄位子
        public void PressCanvas(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        //放開滑鼠，畫圖
        public void ReleaseCanvas(object sender, MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
        }

        //移動滑鼠，紀錄位子
        public void MoveCanvas(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        //畫圖
        public void PaintCanvas(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //更新畫面
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}