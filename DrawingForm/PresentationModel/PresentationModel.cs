using DrawingModel;
using System.Windows.Forms;
using System.ComponentModel;

namespace DrawingForm.PresentationModel
{
    class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private bool _diamondButtonEnable = true;
        private bool _lineButtonEnable = false;
        const string DIAMOND_BUTTON_ENABLE = "DiamondButtonEnable";
        const string LINE_BUTTON_ENABLE = "LineButtonEnable";
        public PresentationModel(Model model, Control canvas)
        {
            _model = model;
        }

        //畫菱形按鈕Enable
        public bool DiamondButtonEnable
        {
            get
            {
                return _diamondButtonEnable;
            }
        }

        //畫線按鈕Enable
        public bool LineButtonEnable
        {
            get
            {
                return _lineButtonEnable;
            }
        }

        //畫圖
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //點擊畫菱形按鈕
        public void ClickDiamondButton()
        {
            _diamondButtonEnable = false;
            _lineButtonEnable = true;
            NotifyPropertyChanged(DIAMOND_BUTTON_ENABLE);
            NotifyPropertyChanged(LINE_BUTTON_ENABLE);
        }

        //點擊畫線按鈕
        public void ClickLineButton()
        {
            _diamondButtonEnable = true;
            _lineButtonEnable = false;
            NotifyPropertyChanged(DIAMOND_BUTTON_ENABLE);
            NotifyPropertyChanged(LINE_BUTTON_ENABLE);
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
