using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

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
        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model.SetShape(new DrawingModel.Line());
            _canvas.PointerPressed += PressCanvas;
            _canvas.PointerReleased += ReleaseCanvas;
            _canvas.PointerMoved += MoveCanvas;
            _diamondButton.Click += DrawDiamond;
            _lineButton.Click += DrawLine;
            _clearButton.Click += ClearPanel;
            _model._modelChanged += HandleModelChanged;
            UpdateButtonEnable();
        }

        //菱形模式
        public void DrawDiamond(object sender, RoutedEventArgs e)
        {
            _model.SetShape(new DrawingModel.Diamond());
            _presentationModel.SetDiamondButtonEnable(false);
            _presentationModel.SetLineButtonEnable(true);
            UpdateButtonEnable();
        }

        //直線模式
        public void DrawLine(object sender, RoutedEventArgs e)
        {
            _model.SetShape(new DrawingModel.Line());
            _presentationModel.SetDiamondButtonEnable(true);
            _presentationModel.SetLineButtonEnable(false);
            UpdateButtonEnable();
        }

        //清除畫面
        private void ClearPanel(object sender, RoutedEventArgs e)
        {
            _model.Clear();
        }

        //滑鼠點擊畫布,紀錄位子
        public void PressCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y);
        }

        //放開滑鼠，畫圖
        public void ReleaseCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y);
        }

        //移動滑鼠，紀錄位子
        public void MoveCanvas(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X,
            e.GetCurrentPoint(_canvas).Position.Y);
        }

        //更新畫面
        public void HandleModelChanged()
        {
            _presentationModel.Draw();
        }

        //更新按鈕狀態
        public void UpdateButtonEnable()
        {
            _diamondButton.IsEnabled = _presentationModel.IsDiamondButtonEnable();
            _lineButton.IsEnabled = _presentationModel.IsLineButtonEnable();
        }
    }
}
