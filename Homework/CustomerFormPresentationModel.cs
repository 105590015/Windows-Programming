using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Homework
{
    public class CustomerFormPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private bool _nextEnable = true;
        private bool _previousEnable = false;
        private bool _addEnable = false;
        private List<string> _buttonPresentationText = new List<string>();
        private List<string> _buttonPresentationImagePath = new List<string>();
        private List<bool> _buttonVisible = new List<bool>();
        private string _descriptionText;
        const string NEXT_ENABLE = "NextEnable";
        const string PREVIOUS_ENABLE = "PreviousEnable";
        const string ADD_ENABLE = "AddEnable";
        const string INITIAL_IMAGE_PATH = "/Image/meal01.png";
        const string END = "\r\n";
        const string UNIT = "元";
        const int BUTTONS = 9;
        const int BASE = 10;
        public CustomerFormPresentationModel(Model model)
        {
            _model = model;
        }

        //下一頁按鈕狀態
        public bool NextEnable
        {
            get
            {
                return _nextEnable;
            }
        }

        //上一頁按鈕狀態
        public bool PreviousEnable
        {
            get
            {
                return _previousEnable;
            }
        }

        //加點按鈕狀態
        public bool AddEnable
        {
            get
            {
                return _addEnable;
            }
        }

        //回傳Model
        public Model GetModel()
        {
            return _model;
        }

        //回傳目前點選的餐點描述
        public string GetDescriptionText()
        {
            return _descriptionText;
        }

        //取得換頁後按鈕應該顯示的餐點名稱列表
        public List<string> GetButtonPresentationText()
        {
            return _buttonPresentationText;
        }

        //取得換頁後按鈕應該顯示的餐點圖片位址列表
        public List<string> GetButtonPresentationImagePath()
        {
            return _buttonPresentationImagePath;
        }

        //取得換頁後按鈕的可見與否列表
        public List<bool> GetButtonVisible()
        {
            return _buttonVisible;
        }

        //餐點類別轉換後處理
        public void ChangeCategory(int tabIndex)
        {
            if (tabIndex >= 0)
            {
                _model.ChangeCategory(tabIndex);
                TurnPage(BASE);
            }
        }

        //點擊餐點
        public void ChangeMeal(int mealIndex)
        {
            _model.SelectMeal(mealIndex);
            _descriptionText = _model.GetSelectedMeal().GetDescribe();
            _addEnable = true;
            NotifyPropertyChanged(ADD_ENABLE);
        }

        //清除目前選擇餐點
        public void ClearMeal()
        {
            _descriptionText = "";
            _addEnable = false;
            NotifyPropertyChanged(ADD_ENABLE);
        }

        //加點餐點
        public void AddMeal()
        {
            _model.AddOrder();
            _addEnable = false;
            NotifyPropertyChanged(ADD_ENABLE);
        }

        //換頁
        public void TurnPage(int change)
        {
            _model.GetComputeModel().ChangePage(change);
            _nextEnable = _model.GetComputeModel().ControlNextButtonEnable();
            NotifyPropertyChanged(NEXT_ENABLE);
            _previousEnable = _model.GetComputeModel().ControlPreviousButtonEnable();
            NotifyPropertyChanged(PREVIOUS_ENABLE);
            _addEnable = false;
            NotifyPropertyChanged(ADD_ENABLE);
        }

        //重設畫面按鈕資訊
        public void RefreshButtonInformation(int categoryIndex)
        {
            ClearButtonInformation();
            List<Meal> meals = _model.CategoriesList[categoryIndex].GetMeals();
            for (int i = _model.GetComputeModel().GetPage() * BUTTONS; i < _model.GetComputeModel().GetPage() * BUTTONS + BUTTONS; i++)
            {
                if (i < meals.Count)
                {
                    _buttonPresentationText.Add(meals[i].Name + END + meals[i].GetPrice().ToString() + UNIT);
                    _buttonPresentationImagePath.Add(meals[i].GetImageRelativePath());
                    _buttonVisible.Add(true);
                }
                else
                {
                    _buttonPresentationText.Add("");
                    _buttonPresentationImagePath.Add(INITIAL_IMAGE_PATH);
                    _buttonVisible.Add(false);
                }
            }
        }

        //清空現存按鈕資訊
        private void ClearButtonInformation()
        {
            _buttonPresentationText.Clear();
            _buttonPresentationImagePath.Clear();
            _buttonVisible.Clear();
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
