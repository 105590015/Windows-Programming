using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Homework
{
    class RestaurantFormMealPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private string _mealName;
        private string _mealCategory;
        private string _mealPrice;
        private string _mealImagePath;
        private string _mealDescription;
        private string _mealGroupBoxTitle = EDIT_MEAL;
        private string _enterMealButtonText = SAVE;
        private bool _enterMealEnable = false;
        private bool _browseEnable = false;
        private bool _mealNameEnable = false;
        private bool _mealPriceEnable = false;
        private bool _categoryComboBoxEnable = false;
        private bool _imagePathEnable = false;
        private bool _mealDescriptionEnable = false;
        const string MEAL_GROUP_BOX_TITLE = "MealGroupBoxTitle";
        const string ENTER_MEAL_BUTTON_TEXT = "EnterMealButtonText";
        const string ENTER_MEAL_ENABLE = "EnterMealEnable";
        const string BROWSE_ENABLE = "BrowseEnable";
        const string MEAL_NAME_ENABLE = "MealNameEnable";
        const string MEAL_PRICE_ENABLE = "MealPriceEnable";
        const string CATEGORY_COMBO_BOX_ENABLE = "CategoryComboBoxEnable";
        const string IMAGE_PATH_ENABLE = "ImagePathEnable";
        const string MEAL_DESCRIPTION_ENABLE = "MealDescriptionEnable";
        const string EDIT_MEAL = "Edit Meal";
        const string ADD_MEAL = "Add Meal";
        const string SAVE = "Save";
        const string ADD = "Add";
        public RestaurantFormMealPresentationModel(Model model)
        {
            _model = model;
        }

        //修改或儲存餐點右半視窗的標題
        public string MealGroupBoxTitle
        {
            get
            {
                return _mealGroupBoxTitle;
            }
        }

        //修改或儲存餐點的按鈕文字
        public string EnterMealButtonText
        {
            get
            {
                return _enterMealButtonText;
            }
        }

        //修改或儲存餐點的按鈕狀態
        public bool EnterMealEnable
        {
            get
            {
                return _enterMealEnable;
            }
        }

        //瀏覽圖片的按鈕狀態
        public bool BrowseEnable
        {
            get
            {
                return _browseEnable;
            }
        }

        //餐點名稱欄位enable
        public bool MealNameEnable
        {
            get
            {
                return _mealNameEnable;
            }
        }

        //餐點價格欄位enable
        public bool MealPriceEnable
        {
            get
            {
                return _mealPriceEnable;
            }
        }

        //餐點類別選單enable
        public bool CategoryComboBoxEnable
        {
            get
            {
                return _categoryComboBoxEnable;
            }
        }

        //餐點圖片位址欄位enable
        public bool ImagePathEnable
        {
            get
            {
                return _imagePathEnable;
            }
        }

        //餐點描述欄位enable
        public bool MealDescriptionEnable
        {
            get
            {
                return _mealDescriptionEnable;
            }
        }

        //回傳Model
        public Model GetModel()
        {
            return _model;
        }

        //取得餐點名稱欄位資料
        public string GetMealName()
        {
            return _mealName;
        }

        //取得餐點單價欄位資料
        public string GetMealPrice()
        {
            return _mealPrice;
        }

        //取得餐點類別欄位資料
        public string GetMealCategory()
        {
            return _mealCategory;
        }

        //取得餐點圖片位址欄位資料
        public string GetMealImagePath()
        {
            return _mealImagePath;
        }

        //取得餐點描述欄位資料
        public string GetMealDescription()
        {
            return _mealDescription;
        }

        //設定餐點名稱欄位資料
        public void SetMealName(string mealName)
        {
            _mealName = mealName;
        }

        //設定餐點單價欄位資料
        public void SetMealPrice(string mealPrice)
        {
            _mealPrice = mealPrice;
        }

        //設定餐點類別欄位資料
        public void SetMealCategory(string mealCategory)
        {
            _mealCategory = mealCategory;
        }

        //設定餐點圖片位址欄位資料
        public void SetMealImagePath(string mealImagePath)
        {
            _mealImagePath = mealImagePath;
        }

        //設定餐點描述位址欄位資料
        public void SetMealDescription(string mealDescription)
        {
            _mealDescription = mealDescription;
        }

        //設定餐點欄位enable
        public void SetFieldEnable(bool enable)
        {
            _mealNameEnable = enable;
            _mealPriceEnable = enable;
            _categoryComboBoxEnable = enable;
            _imagePathEnable = enable;
            _mealDescriptionEnable = enable;
            NotifyPropertyChanged(MEAL_NAME_ENABLE);
            NotifyPropertyChanged(MEAL_PRICE_ENABLE);
            NotifyPropertyChanged(CATEGORY_COMBO_BOX_ENABLE);
            NotifyPropertyChanged(IMAGE_PATH_ENABLE);
            NotifyPropertyChanged(MEAL_DESCRIPTION_ENABLE);
        }

        //查詢並儲存餐點資料
        public void SearchMealData(int index)
        {
            BindingList<Meal> mealsList = _model.MealsList;
            _mealName = mealsList[index].Name;
            _mealCategory = mealsList[index].GetCategoryName();
            _mealPrice = mealsList[index].GetPrice().ToString();
            _mealImagePath = mealsList[index].GetImageRelativePath();
            _mealDescription = mealsList[index].GetDescribe();
        }

        //重設餐點欄位資料
        public void ResetFieldData()
        {
            _mealName = "";
            _mealCategory = _model.MealsList[0].GetCategoryName();
            _mealPrice = "";
            _mealImagePath = "";
            _mealDescription = "";
        }

        //清空餐點格子資料
        public void ClearMealData()
        {
            SetFieldEnable(false);
            _enterMealEnable = false;
            _browseEnable = false;
            ResetFieldData();
            NotifyChangeDataOfMeal();
        }

        //通知餐點相關的資料變化
        public void NotifyChangeDataOfMeal()
        {
            NotifyPropertyChanged(MEAL_GROUP_BOX_TITLE);
            NotifyPropertyChanged(ENTER_MEAL_BUTTON_TEXT);
            NotifyPropertyChanged(ENTER_MEAL_ENABLE);
            NotifyPropertyChanged(BROWSE_ENABLE);
        }

        //進入編輯餐點模式
        public void ChangeEditMealMode(int index)
        {
            SetFieldEnable(true);
            SearchMealData(index);
            _mealGroupBoxTitle = EDIT_MEAL;
            _enterMealButtonText = SAVE;
            _model.JudgeDeleteMealEnable(index);
            _enterMealEnable = false;
            _browseEnable = true;
            NotifyChangeDataOfMeal();
        }

        //進入新增餐點模式
        public void ChangeAddMealMode()
        {
            SetFieldEnable(true);
            ResetFieldData();
            _mealGroupBoxTitle = ADD_MEAL;
            _enterMealButtonText = ADD;
            _model.DisableMealDelete();
            _enterMealEnable = false;
            _browseEnable = true;
            NotifyChangeDataOfMeal();
        }

        //儲存或新增餐點
        public void EnterMeal(int index)
        {
            try
            {
                string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                Meal meal = new Meal(_mealName, _model.GetCategoryByName(_mealCategory), Int32.Parse(_mealPrice), _mealImagePath, _mealDescription);
                Image image = Image.FromFile(projectPath + _mealImagePath);
                if (_enterMealButtonText == SAVE)
                    _model.EditMeal(meal, index);
                else
                    _model.AddMeal(meal);
            }
            catch
            {
                const string INPUT_ILLEGAL = "輸入資料不合法";
                const string INPUT_ERROR = "輸入錯誤";
                MessageBox.Show(INPUT_ILLEGAL, INPUT_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SearchMealData(index);
            }
        }

        //判斷輸入變化
        public void JudgeModifyData(string name, string price, string category, string imagePath, string description)
        {
            _enterMealEnable = false;
            if (name != "" && price != "" && category != "" && imagePath != "")
                if (name != _mealName || price != _mealPrice || category != _mealCategory || imagePath != _mealImagePath || description != _mealDescription)
                    _enterMealEnable = true;
            NotifyPropertyChanged(ENTER_MEAL_ENABLE);
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
