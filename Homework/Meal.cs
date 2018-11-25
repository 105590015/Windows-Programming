using System;
using System.ComponentModel;

namespace Homework
{
    public class Meal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private Category _category;
        private int _price;
        private string _imageRelativePath;
        private string _describe;
        const string NAME = "Name";
        public Meal(string name, Category category, int price, string imageRelativePath, string describe)
        {
            _name = name;
            _category = category;
            _price = price;
            _imageRelativePath = imageRelativePath;
            _describe = describe;
        }

        //名子
        public string Name
        {
            get
            {
                return _name;
            }
        }

        //取得餐點類別
        public Category GetCategory()
        {
            return _category;
        }

        //取得餐點類別名稱
        public string GetCategoryName()
        {
            return _category.Name;
        }

        //取得餐點價格
        public int GetPrice()
        {
            return _price;
        }

        //取得圖檔相對位子
        public string GetImageRelativePath()
        {
            return _imageRelativePath;
        }

        //取得餐點描述
        public string GetDescribe()
        {
            return _describe;
        }

        //判斷是不是同個類別
        public bool IsSameCategory(Meal meal)
        {
            if (_category == meal.GetCategory())
                return true;
            else
                return false;
        }
    }
}
