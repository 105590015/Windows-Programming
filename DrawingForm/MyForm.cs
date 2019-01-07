using System;
using System.Windows.Forms;
using System.Threading;

namespace DrawingForm
{
    public partial class MyForm : Form
    {
        private DrawingModel.Model _model;
        private PresentationModel.PresentationModel _presentationModel;
        const string ENABLE = "Enabled";
        const string ELLIPSE = "Ellipse";
        const string DIAMOND = "Diamond";
        const string LINE = "Line";
        const string PATH_DETAIL = "/bin/Debug";
        public MyForm()
        {
            InitializeComponent();
            string credentialPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            _model = new DrawingModel.Model(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())), PATH_DETAIL, credentialPath, true);
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model.CreateShape(LINE);
            _canvas.MouseDown += PressCanvas;
            _canvas.MouseUp += ReleaseCanvas;
            _canvas.MouseUp += InitializeButtonState;
            _canvas.MouseMove += MoveCanvas;
            _canvas.Paint += PaintCanvas;
            _ellipseButton.Click += DrawEllipse;
            _diamondButton.Click += DrawDiamond;
            _lineButton.Click += DrawLine;
            _clearButton.Click += ClearPanel;
            _undoButton.Click += Undo;
            _redoButton.Click += Redo;
            _saveButton.Click += SaveImage;
            _loadButton.Click += LoadImage;
            _ellipseButton.DataBindings.Add(ENABLE, _presentationModel, "EllipseButtonEnable");
            _lineButton.DataBindings.Add(ENABLE, _presentationModel, "LineButtonEnable");
            _diamondButton.DataBindings.Add(ENABLE, _presentationModel, "DiamondButtonEnable");
            _undoButton.Enabled = false;
            _redoButton.Enabled = false;
        }

        //橢圓模式
        public void DrawEllipse(object sender, EventArgs e)
        {
            _model.CreateShape(ELLIPSE);
            _presentationModel.ClickEllipseButton();
        }

        //菱形模式
        public void DrawDiamond(object sender, EventArgs e)
        {
            _model.CreateShape(DIAMOND);
            _presentationModel.ClickDiamondButton();
        }

        //直線模式
        public void DrawLine(object sender, EventArgs e)
        {
            _model.CreateShape(LINE);
            _presentationModel.ClickLineButton();
        }

        //清除畫面
        public void ClearPanel(object sender, EventArgs e)
        {
            _model.Clear();
            HandleModelChanged();
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
            HandleModelChanged();
        }

        //移動滑鼠，紀錄位子
        public void MoveCanvas(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
            HandleModelChanged();
        }

        //畫圖
        public void PaintCanvas(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //上一步
        public void Undo(object sender, EventArgs e)
        {
            _model.GetCommandManager().Undo();
            HandleModelChanged();
        }

        //還原一步
        public void Redo(object sender, EventArgs e)
        {
            _model.GetCommandManager().Redo();
            HandleModelChanged();
        }

        //初始化按鈕狀態
        public void InitializeButtonState(object sender, EventArgs e)
        {
            _presentationModel.InitializeButtonState();
        }

        //儲存圖片資訊
        public void SaveImage(object sender, EventArgs e)
        {
            Thread worker = new Thread(_model.SaveImage);
            worker.Start();
        }

        //讀取圖片資訊
        public void LoadImage(object sender, EventArgs e)
        {
            _model.LoadImage();
        }

        //更新畫面
        public void HandleModelChanged()
        {
            Invalidate(true);
            _undoButton.Enabled = _model.GetCommandManager().IsUndoEnabled;
            _redoButton.Enabled = _model.GetCommandManager().IsRedoEnabled;
        }
    }
}