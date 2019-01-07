using Windows.UI.Xaml.Controls;
using DrawingModel;

namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        private Model _model;
        private IGraphics _graphics;
        private bool _ellipseButtonEnable = true;
        private bool _diamondButtonEnable = true;
        private bool _lineButtonEnable = false;
        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _graphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        //取得畫橢圓按鈕enalbe
        public bool IsEllipseButtonEnable()
        {
            return _ellipseButtonEnable;
        }

        //取得畫菱形按鈕enalbe
        public bool IsDiamondButtonEnable()
        {
            return _diamondButtonEnable;
        }

        //取得畫線按鈕enalbe
        public bool IsLineButtonEnable()
        {
            return _lineButtonEnable;
        }

        //設定畫橢圓按鈕enable
        public void SetEllipseButtonEnable(bool enable)
        {
            _ellipseButtonEnable = enable;
        }

        //設定畫菱形按鈕enable
        public void SetDiamondButtonEnable(bool enable)
        {
            _diamondButtonEnable = enable;
        }

        //設定畫線按鈕enable
        public void SetLineButtonEnable(bool enable)
        {
            _lineButtonEnable = enable;
        }

        //畫圖
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphics);
        }
    }
}