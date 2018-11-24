using System;
using System.ComponentModel;

namespace Homework
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _categoryName;
        private int _price;
        private int _quantity;
        private int _subtotal;
        const string UNIT = "元";
        const string NAME = "Name";
        const string CATEGORY_NAME = "Category";
        const string PRICE = "Price";
        const string QUANTITY = "Quantity";
        const string SUBTOTAL = "Subtotal";
        public Order(string name, string categoryName, int price, int quantity, int subtotal)
        {
            _name = name;
            _categoryName = categoryName;
            _price = price;
            _quantity = quantity;
            _subtotal = subtotal;
        }

        //名子
        public string Name
        {
            get
            {
                return _name;
            }
        }

        //類別名稱
        public string Category
        {
            get
            {
                return _categoryName;
            }
        }

        //單價
        public string Price
        {
            get
            {
                return _price.ToString() + UNIT;
            }
        }

        //數量
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                _subtotal = _quantity * _price;
                NotifyPropertyChanged(QUANTITY);
                NotifyPropertyChanged(SUBTOTAL);
            }
        }

        //單品項總價
        public String Subtotal
        {
            get
            {
                return _subtotal.ToString() + UNIT;
            }
        }

        //數量加一
        public void AddQuantity()
        {
            _quantity++;
            _subtotal = _quantity * _price;
            NotifyPropertyChanged(QUANTITY);
            NotifyPropertyChanged(SUBTOTAL);
        }

        //由於餐點資料改變而重設資料
        public void ResetData(Meal meal)
        {
            _name = meal.Name;
            _categoryName = meal.GetCategory().Name;
            _price = meal.GetPrice();
            _subtotal = _quantity * _price;
            NotifyPropertyChanged(NAME);
            NotifyPropertyChanged(CATEGORY_NAME);
            NotifyPropertyChanged(PRICE);
            NotifyPropertyChanged(SUBTOTAL);
        }

        //由於類別資料改變而重設資料
        public void ResetData(Category category)
        {
            _categoryName = category.Name;
            NotifyPropertyChanged(CATEGORY_NAME);
        }

        //通知數值變化
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
