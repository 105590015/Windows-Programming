using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace Homework
{
    class RestaurantFormCategoryPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model _model;
        private string _categoryName;
        private string _categoryGroupBoxTitle = EDIT_CATEGORY;
        private string _enterCategoryButtonText = SAVE;
        private bool _enterCategoryEnable = false;
        private bool _deleteCategoryEnable = false;
        private bool _categoryNameEnable = false;
        const string CATEGORY_GROUP_BOX_TITLE = "CategoryGroupBoxTitle";
        const string ENTER_CATEGORY_BUTTON_TEXT = "EnterCategoryButtonText";
        const string ENTER_CATEGORY_ENABLE = "EnterCategoryEnable";
        const string DELETE_CATEGORY_ENABLE = "DeleteCategoryEnable";
        const string CATEGORY_NAME_ENABLE = "CategoryNameEnable";
        const string EDIT_CATEGORY = "Edit Category";
        const string ADD_CATEGORY = "Add Category";
        const string SAVE = "Save";
        const string ADD = "Add";
        public RestaurantFormCategoryPresentationModel(Model model)
        {
            _model = model;
        }

        //修改或儲存類別右半視窗的標題
        public string CategoryGroupBoxTitle
        {
            get
            {
                return _categoryGroupBoxTitle;
            }
        }

        //修改或儲存類別的按鈕文字
        public string EnterCategoryButtonText
        {
            get
            {
                return _enterCategoryButtonText;
            }
        }

        //修改或儲存類別的按鈕狀態
        public bool EnterCategoryEnable
        {
            get
            {
                return _enterCategoryEnable;
            }
        }

        //刪除類別的按鈕狀態
        public bool DeleteCategoryEnable
        {
            get
            {
                return _deleteCategoryEnable;
            }
        }

        //類別名稱欄位enable
        public bool CategoryNameEnable
        {
            get
            {
                return _categoryNameEnable;
            }
        }

        //回傳Model
        public Model GetModel()
        {
            return _model;
        }

        //取得類別名稱資料
        public string GetCategoryName()
        {
            return _categoryName;
        }

        //設定類別名稱資料
        public void SetCategoryName(string categoryName)
        {
            _categoryName = categoryName;
        }

        //關閉刪除類別功能
        public void DisableCategoryDelete()
        {
            _deleteCategoryEnable = false;
            NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
        }

        //設定類別欄位enable
        public void SetFieldEnable(bool enable)
        {
            _categoryNameEnable = enable;
            NotifyPropertyChanged(CATEGORY_NAME_ENABLE);
        }

        //清空類別格子資料
        public void ClearCategoryData()
        {
            SetFieldEnable(false);
            _enterCategoryEnable = false;
            _deleteCategoryEnable = false;
            _categoryName = "";
            _model.ClearUsedList();
            NotifyChangeDataOfCategory();
        }

        //通知類別相關的資料變化
        public void NotifyChangeDataOfCategory()
        {
            NotifyPropertyChanged(CATEGORY_GROUP_BOX_TITLE);
            NotifyPropertyChanged(ENTER_CATEGORY_BUTTON_TEXT);
            NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
            NotifyPropertyChanged(CATEGORY_NAME_ENABLE);
        }

        //改成編輯類別模式
        public void ChangeEditCategoryMode(int index)
        {
            SetFieldEnable(true);
            BindingList<Category> categoriesList = _model.CategoriesList;
            _categoryGroupBoxTitle = EDIT_CATEGORY;
            _enterCategoryButtonText = SAVE;
            _model.RefreshUsedList(index);
            if (categoriesList[index].GetMeals().Count == 0)
                _deleteCategoryEnable = true;
            else
                _deleteCategoryEnable = false;
            _enterCategoryEnable = false;
            _categoryName = categoriesList[index].Name;
            _categoryNameEnable = true;
            NotifyChangeDataOfCategory();
        }

        //改成新增類別模式
        public void ChangeAddCategoryMode()
        {
            SetFieldEnable(true);
            _categoryGroupBoxTitle = ADD_CATEGORY;
            _enterCategoryButtonText = ADD;
            _model.ClearUsedList();
            _enterCategoryEnable = false;
            _deleteCategoryEnable = false;
            _categoryName = "";
            NotifyChangeDataOfCategory();
        }

        //儲存或新增類別
        public void EnterCategory(int index)
        {
            Category category = new Category(_categoryName);
            if (_enterCategoryButtonText == SAVE)
                _model.EditCategory(category, index);
            else
            {
                _model.AddCategory(category);
                _deleteCategoryEnable = true;
                NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
            }
        }

        //判斷是否修改類別數值
        public void JudgeModifyData(string name)
        {
            _enterCategoryEnable = false;
            if (name != "" && name != _categoryName)
                _enterCategoryEnable = true;
            NotifyPropertyChanged(ENTER_CATEGORY_ENABLE);
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
