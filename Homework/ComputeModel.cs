using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Homework
{
    public class ComputeModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _page = 0;
        private int _totalPage = 0;
        private int _selectedMealOfRestaurant = 0;
        private int _selectedCategoryOfRestaurant = 0;
        private bool _deleteMealEnable = false;
        private bool _deleteCategoryEnable = false;
        const string DELETE_MEAL_ENABLE = "DeleteMealEnable";
        const string DELETE_CATEGORY_ENABLE = "DeleteCategoryEnable";
        //刪除餐點的按鈕狀態
        public bool DeleteMealEnable
        {
            get
            {
                return _deleteMealEnable;
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

        //設定刪除餐點按鈕功能
        public void SetDeleteMealEnable(bool type)
        {
            _deleteMealEnable = type;
            NotifyPropertyChanged(DELETE_MEAL_ENABLE);
        }

        //設定刪除類別按鈕功能
        public void SetDeleteCategoryEnable(bool type)
        {
            _deleteCategoryEnable = type;
            NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
        }

        //確認餐點是否被選購
        public bool CheckOrder(Meal meal, BindingList<Order> ordersList)
        {
            bool ordered = false;
            for (int i = 0; i < ordersList.Count; i++)
            {
                if (ordersList[i].Name == meal.Name)
                {
                    ordered = true;
                    break;
                }
            }
            return ordered;
        }

        //判斷是否可以刪除餐點
        public void JudgeDeleteMealEnable(Meal meal, BindingList<Order> ordersList)
        {
            _deleteMealEnable = !CheckOrder(meal, ordersList);
            NotifyPropertyChanged(DELETE_MEAL_ENABLE);
        }

        //判斷是否可以刪除類別
        public void JudgeDeleteCategoryEnable(List<Meal> meals, BindingList<Order> ordersList)
        {
            _deleteCategoryEnable = true;
            for (int i = 0; i < meals.Count; i++)
            {
                if (CheckOrder(meals[i], ordersList))
                {
                    _deleteCategoryEnable = false;
                    break;
                }
                    
            }
            NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
        }

        //取得當前頁數
        public int GetPage()
        {
            return _page;
        }

        //換頁
        public void ChangePage(int buttonIndex)
        {
            const int BASE = 10;
            _page += buttonIndex - BASE;
        }

        //取得頁碼資訊
        public string GetPageInformation()
        {
            const string PAGE = "Page：";
            const string SLASH = " / ";
            return PAGE + (_page + 1).ToString() + SLASH + _totalPage.ToString();
        }

        //重置頁碼
        public void ResetPage(int mealsCount)
        {
            const int BUTTONS = 9;
            _page = 0;
            if (mealsCount % BUTTONS == 0 && mealsCount / BUTTONS != 0)
                _totalPage = mealsCount / BUTTONS;
            else
                _totalPage = mealsCount / BUTTONS + 1;
        }

        //控制上一頁按鈕enable
        public bool ControlPreviousButtonEnable()
        {
            if (_page > 0)
                return true;
            else
                return false;
        }

        //控制下一頁按鈕enable
        public bool ControlNextButtonEnable()
        {
            if (_totalPage > _page + 1)
                return true;
            else
                return false;
        }

        //讀檔
        public void ReadFile(List<string> list, string path)
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string line;
            StreamReader file = new StreamReader(projectPath + path, System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
                list.Add(line);
        }

        //轉換成相對位子
        public string TransformRelativePath(string absolutePath)
        {
            const string HOMEWORK = "Homework";
            const char SLASH = '\\';
            string folderName = "";
            int start = 0;
            for (int i = 0; i < absolutePath.Length; i++)
            {
                if (absolutePath[i] == SLASH && folderName == HOMEWORK)
                {
                    start = i;
                    break;
                }
                else if (absolutePath[i] == SLASH)
                    folderName = "";
                else
                    folderName += absolutePath[i];
            }
            return absolutePath.Substring(start, absolutePath.Length - start);
        }

        //取得對應名稱的類別
        public Category GetCategoryByName(string name, BindingList<Category> categoriesList)
        {
            Category category = null;
            for (int i = 0; i < categoriesList.Count; i++)
            {
                if (categoriesList[i].Name == name)
                    category = categoriesList[i];
            }
            return category;
        }

        //金額字串轉數值
        public int ChangeInteger(string price)
        {
            int integer = 0;
            const int TEN = 10;
            const char ZERO = '0';
            for (int i = 0; i < price.Length; i++)
            {
                if (char.IsDigit(price[i]))
                    integer = integer * TEN + (price[i] - ZERO);
                else
                    break;
            }
            return integer;
        }

        //取得總金額
        public int GetTotalPrice(BindingList<Order> ordersList)
        {
            int totalPrice = 0;
            for (int i = 0; i < ordersList.Count; i++)
            {
                totalPrice += ChangeInteger(ordersList[i].Subtotal);
            }
            return totalPrice;
        }

        //設定商家端選擇的餐點序號
        public void SetSelectedMealOfRestaurant(int index)
        {
            _selectedMealOfRestaurant = index;
        }

        //取的商家端選擇的餐點序號
        public int GetSelectedMealOfRestaurant()
        {
            return _selectedMealOfRestaurant;
        }

        //設定商家端選擇的類別序號
        public void SetSelectedCategoryOfRestaurant(int index)
        {
            _selectedCategoryOfRestaurant = index;
        }

        //取的商家端選擇的類別序號
        public int GetSelectedCategoryOfRestaurant()
        {
            return _selectedCategoryOfRestaurant;
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
