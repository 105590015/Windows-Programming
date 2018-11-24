using System;

namespace Homework1
{
    class Meal
    {
        private String _name;
        private int _price;
        public Meal(String name, int price)
        {
            _name = name;
            _price = price;
        }

        //取得餐點名稱
        public String GetName()
        {
            return _name;
        }

        //取得餐點價格
        public int GetPrice()
        {
            return _price;
        }
    }
}
