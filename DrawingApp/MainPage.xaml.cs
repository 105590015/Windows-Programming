using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DrawingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DrawingModel.Model _model;
        private PresentationModel.PresentationModel _presentationModel;
        const string ELLIPSE = "Ellipse";
        const string DIAMOND = "Diamond";
        const string LINE = "Line";
        const string PATH_DETAIL = "";
        public MainPage()
        {
            InitializeComponent();
            string credentialPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            _model = new DrawingModel.Model(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()), PATH_DETAIL, credentialPath, false);
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
            _model.CreateShape(LINE);
            _canvas.PointerPressed += PressCanvas;
            _canvas.PointerReleased += ReleaseCanvas;
            _canvas.PointerReleased += InitializeButtonState;
            _canvas.PointerMoved += MoveCanvas;
            _ellipseButton.Click += DrawEllipse;
            _diamondButton.Click += DrawDiamond;
            _lineButton.Click += DrawLine;
            _clearButton.Click += ClearPanel;
            _undoButton.Click += Undo;
            _redoButton.Click += Redo;
            _saveButton.Click += SaveImage;
            _loadButton.Click += LoadImage;
            UpdateButtonEnable();
        }

        //橢圓模式
        public void DrawEllipse(object sender, RoutedEventArgs e)
        {
            _model.CreateShape(ELLIPSE);
            _presentationModel.SetEllipseButtonEnable(false);
            _presentationModel.SetDiamondButtonEnable(true);
            _presentationModel.SetLineButtonEnable(true);
            UpdateButtonEnable();
        }

        //菱形模式
        public void DrawDiamond(object sender, RoutedEventArgs e)
        {
            _model.CreateShape(DIAMOND);
            _presentationModel.SetEllipseButtonEnable(true);
            _presentationModel.SetDiamondButtonEnable(false);
            _presentationModel.SetLineButtonEnable(true);
            UpdateButtonEnable();
        }

        //直線模式
        public void DrawLine(object sender, RoutedEventArgs e)
        {
            _model.CreateShape(LINE);
            _presentationModel.SetEllipseButtonEnable(true);
            _presentationModel.SetDiamondButtonEnable(true);
            _presentationModel.SetLineButtonEnable(false);
            UpdateButtonEnable();
        }

        //清除畫面
        private void ClearPanel(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            HandleModelChanged();
        }

        //滑鼠點擊畫布,紀錄位子
        public void PressCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        //放開滑鼠，畫圖
        public void ReleaseCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            HandleModelChanged();
        }

        //移動滑鼠，紀錄位子
        public void MoveCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            HandleModelChanged();
        }

        //更新畫面
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
            UpdateButtonEnable();
        }

        //上一步
        public void Undo(object sender, RoutedEventArgs e)
        {
            _model.GetCommandManager().Undo();
            HandleModelChanged();
        }

        //上一步
        public void Redo(object sender, RoutedEventArgs e)
        {
            _model.GetCommandManager().Redo();
            HandleModelChanged();
        }

        //儲存圖片資訊
        public void SaveImage(object sender, RoutedEventArgs e)
        {
        }

        //讀取圖片資訊
        public void LoadImage(object sender, RoutedEventArgs e)
        {
        }

        //初始化按鈕狀態
        public void InitializeButtonState(object sender, RoutedEventArgs e)
        {
            _presentationModel.SetEllipseButtonEnable(true);
            _presentationModel.SetDiamondButtonEnable(true);
            _presentationModel.SetLineButtonEnable(true);
            UpdateButtonEnable();
        }

        //更新按鈕狀態
        public void UpdateButtonEnable()
        {
            _ellipseButton.IsEnabled = _presentationModel.IsEllipseButtonEnable();
            _diamondButton.IsEnabled = _presentationModel.IsDiamondButtonEnable();
            _lineButton.IsEnabled = _presentationModel.IsLineButtonEnable();
            _undoButton.IsEnabled = _model.GetCommandManager().IsUndoEnabled;
            _redoButton.IsEnabled = _model.GetCommandManager().IsRedoEnabled;
        }
    }
}
