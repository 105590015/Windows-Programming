using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Homework
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private ComputeModel _computeModel = new ComputeModel();
        private int _tabIndex;
        private Meal _selectedMeal;
        private BindingList<Meal> _mealsList = new BindingList<Meal>();
        private BindingList<Category> _categoriesList = new BindingList<Category>();
        private BindingList<Order> _ordersList = new BindingList<Order>();
        private BindingList<Meal> _mealsUsingThisCategoryList = new BindingList<Meal>();
        const string MEALS_NAME_PATH = "/mealsName.txt";
        const string MEALS_CATEGORY_PATH = "/mealsCategory.txt";
        const string MEALS_PRICE_PATH = "/mealsPrice.txt";
        const string MEALS_IMAGE_PATH = "/mealsImagePath.txt";
        const string MEALS_DESCRIBE_PATH = "/mealsDescribe.txt";
        const string HAMBURGER = "漢堡";
        const string PACKAGE = "套餐";
        const string BEVERAGE = "飲料";
        const int BUTTONS = 9;
        public Model()
        {
            CreateInitialCategories();
            CreateInitialMeals();
            _computeModel.ResetPage(_categoriesList[0].GetMeals().Count);
        }

        //菜單列表
        public BindingList<Meal> MealsList
        {
            get
            {
                return _mealsList;
            }
        }

        //類別列表
        public BindingList<Category> CategoriesList
        {
            get
            {
                return _categoriesList;
            }
        }

        //訂單資訊
        public BindingList<Order> OrdersList
        {
            get
            {
                return _ordersList;
            }
        }

        //使用目前類別的餐點列表
        public BindingList<Meal> MealsUsingThisCategoryList
        {
            get
            {
                return _mealsUsingThisCategoryList;
            }
        }

        //取得ComputeModel
        public ComputeModel GetComputeModel()
        {
            return _computeModel;
        }

        //判斷是否可以刪除餐點
        public void JudgeDeleteMealEnable(int index)
        {
            if (index > -1)
            {
                Meal meal = _mealsList[index];
                _computeModel.JudgeDeleteMealEnable(meal, _ordersList);
            }
        }

        //判斷是否可以刪除類別
        public void JudgeDeleteCategoryEnable(int index)
        {
            if (index > -1)
            {
                List<Meal> meals = CategoriesList[index].GetMeals();
                _computeModel.JudgeDeleteCategoryEnable(meals, OrdersList);
            }
        }

        //建立基礎類別
        public void CreateInitialCategories()
        {
            Category hamburger = new Category(HAMBURGER);
            _categoriesList.Add(hamburger);
            Category package = new Category(PACKAGE);
            _categoriesList.Add(package);
            Category beverage = new Category(BEVERAGE);
            _categoriesList.Add(beverage);
        }

        // 建立基礎菜單
        public void CreateInitialMeals()
        {
            List<string> mealsNameList = new List<string>();
            _computeModel.ReadFile(mealsNameList, MEALS_NAME_PATH);
            List<string> mealsCategoryList = new List<string>();
            _computeModel.ReadFile(mealsCategoryList, MEALS_CATEGORY_PATH);
            List<string> mealsPriceList = new List<string>();
            _computeModel.ReadFile(mealsPriceList, MEALS_PRICE_PATH);
            List<string> mealImagePathList = new List<string>();
            _computeModel.ReadFile(mealImagePathList, MEALS_IMAGE_PATH);
            List<string> mealDescribeList = new List<string>();
            _computeModel.ReadFile(mealDescribeList, MEALS_DESCRIBE_PATH);
            for (int i = 0; i < mealsNameList.Count; i++)
            {
                Category category = GetCategoryByName(mealsCategoryList[i]);
                Meal meal = new Meal(mealsNameList[i], category, Int32.Parse(mealsPriceList[i]), mealImagePathList[i], mealDescribeList[i]);
                category.AddMeal(meal);
                _mealsList.Add(meal);
            }
        }

        //儲存被點擊的餐點
        public void SelectMeal(int whichButton)
        {
            int whichMeal = _computeModel.GetPage() * BUTTONS + whichButton;
            _selectedMeal = _categoriesList[_tabIndex].GetMeals()[whichMeal];
        }

        //取得被點擊的餐點
        public Meal GetSelectedMeal()
        {
            return _selectedMeal;
        }

        //取得對應名稱的類別
        public Category GetCategoryByName(String name)
        {
            return _computeModel.GetCategoryByName(name, _categoriesList);
        }

        //切換類別頁面並更新頁碼資訊
        public void ChangeCategory(int tabIndex)
        {
            _tabIndex = tabIndex;
            _computeModel.ResetPage(_categoriesList[tabIndex].GetMeals().Count);
        }

        //取得總金額資訊
        public string GetTotalPriceInformation()
        {
            const string TOTAL = "Total：";
            const string UNIT = "元";
            return TOTAL + _computeModel.GetTotalPrice(_ordersList).ToString() + UNIT;
        }

        //加點餐點
        public void AddOrder()
        {
            bool repeat = false;
            Meal meal = GetSelectedMeal();
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (meal.Name == _ordersList[i].Name)
                {
                    _ordersList[i].AddQuantity();
                    repeat = true;
                    break;
                }
            }
            if (!repeat)
                _ordersList.Add(new Order(meal.Name, meal.GetCategoryName(), meal.GetPrice(), 1, meal.GetPrice()));
            JudgeDeleteMealEnable(_computeModel.GetSelectedMealOfRestaurant());
            JudgeDeleteCategoryEnable(_computeModel.GetSelectedCategoryOfRestaurant());
        }

        //刪除點餐
        public void DeleteOrder(int position)
        {
            _ordersList.RemoveAt(position);
            JudgeDeleteMealEnable(_computeModel.GetSelectedMealOfRestaurant());
            JudgeDeleteCategoryEnable(_computeModel.GetSelectedCategoryOfRestaurant());
        }

        //因菜單改變而更新訂單
        public void RefreshOrder(Meal oldMeal, Meal meal)
        {
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (_ordersList[i].Name == oldMeal.Name)
                    _ordersList[i].ResetData(meal); 
            }
        }

        //因類別改變而更新訂單
        public void RefreshOrder(Category oldCategory, Category category)
        {
            for (int i = 0; i < _ordersList.Count; i++)
            {
                if (_ordersList[i].Category == oldCategory.Name)
                    _ordersList[i].ResetData(category);
            }
        }

        //清空點餐
        public void ClearOrders()
        {
            _ordersList.Clear();
        }

        //修改餐點
        public void EditMeal(Meal meal, int index)
        {
            Category category = _mealsList[index].GetCategory();
            if (meal.IsSameCategory(_mealsList[index]))
                category.EditMeal(meal, _mealsList[index].Name);
            else
            {
                category.GetMeals().Remove(_mealsList[index]);
                meal.GetCategory().AddMeal(meal);
            }
            RefreshOrder(_mealsList[index], meal);
            _mealsList[index] = meal;
            NotifyObserver();
        }

        //新增餐點
        public void AddMeal(Meal meal)
        {
            Category category = meal.GetCategory();
            category.AddMeal(meal);
            _mealsList.Add(meal);
            _computeModel.SetDeleteMealEnable(true);
            NotifyObserver();
        }

        //刪除餐點
        public void DeleteMeal(int index)
        {
            Meal meal = _mealsList[index];
            Category category = meal.GetCategory();
            category.GetMeals().Remove(meal);
            _mealsList.Remove(meal);
            _computeModel.SetDeleteMealEnable(false);
            NotifyObserver();
        }

        //更新使用目前類別的餐點列表
        public void RefreshUsedList(int index)
        {
            _mealsUsingThisCategoryList.Clear();
            for (int i = 0; i < _categoriesList[index].GetMeals().Count; i++)
            {
                _mealsUsingThisCategoryList.Add(_categoriesList[index].GetMeals()[i]);
            }
        }

        //清除使用目前類別的餐點列表
        public void ClearUsedList()
        {
            _mealsUsingThisCategoryList.Clear();
        }

        //修改類別
        public void EditCategory(Category category, int index)
        {
            RefreshOrder(_categoriesList[index], category);
            _categoriesList[index].Name = category.Name;
            NotifyObserver();
        }

        //新增類別
        public void AddCategory(Category category)
        {
            _categoriesList.Add(category);
            NotifyObserver();
        }

        //刪除類別
        public void DeleteCategory(int index)
        {
            _categoriesList[index].ClearMeals(_mealsList);
            _categoriesList.RemoveAt(index);
            NotifyObserver();
        }

        //通知View變化
        public void NotifyObserver()
        {
            if (_modelChanged != null)
                _modelChanged.Invoke();
        }
    }
}