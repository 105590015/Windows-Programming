using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private List<Meal> _meals = new List<Meal>();
        const string NAME = "Name";
        public Category(string name)
        {
            _name = name;
        }

        //名子
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(NAME);
            }
        }

        //取得屬於此類別的餐點列表
        public List<Meal> GetMeals()
        {
            return _meals;
        }

        //新增屬此類別的餐點
        public void AddMeal(Meal meal)
        {
            _meals.Add(meal);
        }

        //修改餐點資料
        public void EditMeal(Meal meal, string name)
        {
            for (int i = 0; i < _meals.Count; i++)
            {
                if (_meals[i].Name == name)
                    _meals[i] = meal;
            }
        }

        //通知數值變化
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
