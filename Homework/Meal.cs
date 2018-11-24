using System;

namespace Homework
{
    class Meal
    {
        private String _name;
        private int _price;
        private String _imageRelativePath;
        private String _describe;
        public Meal(String name, int price, String imageRelativePath, String describe)
        {
            _name = name;
            _price = price;
            _imageRelativePath = imageRelativePath;
            _describe = describe;
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

        //取得圖檔相對位子
        public String GetImageRelativePath()
        {
            return _imageRelativePath;
        }

        //取得餐點描述
        public String GetDescribe()
        {
            return _describe;
        }
    }
}
