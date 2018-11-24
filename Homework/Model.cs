using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    class Model
    {
        private int _page = 0;
        private Meal _selectedMeal = null;
        private Order _order = new Order();
        private List<Meal> _mealList = new List<Meal>();
        const String MEAL_NAME_PATH = "/mealName.txt";
        const String MEAL_PRICE_PATH = "/mealPrice.txt";
        const String MEAL_IMAGE_PATH = "/mealImagePath.txt";
        const String MEAL_DESCRIBE_PATH = "/mealDescribe.txt";
        const String PAGE = "Page：";
        const String SLASH = " / ";
        const String TOTAL = "Total：";
        const String UNIT = "元";
        const int BUTTONS = 9;
        const int BASE = 10;
        // 建立基礎菜單
        public void CreateInitialMeals()
        {
            List<String> meals = new List<string>();
            ReadFile(meals, MEAL_NAME_PATH);
            List<String> prices = new List<string>();
            ReadFile(prices, MEAL_PRICE_PATH);
            List<String> mealImagePath = new List<string>();
            ReadFile(mealImagePath, MEAL_IMAGE_PATH);
            List<String> mealDescribe = new List<string>();
            ReadFile(mealDescribe, MEAL_DESCRIBE_PATH);
            for (int i = 0; i < meals.Count; i++)
                _mealList.Add(new Meal(meals[i], Int32.Parse(prices[i]), mealImagePath[i], mealDescribe[i]));
        }

        //讀檔
        public void ReadFile(List<String> list, String path)
        {
            String projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            String line;
            StreamReader file = new StreamReader(projectPath + path, System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
                list.Add(line);
        }

        //取得菜單
        public List<Meal> GetMealList()
        {
            return _mealList;
        }

        //取得第index項餐點資料
        public Meal GetMeal(int index)
        {
            return _mealList[_page * BUTTONS + index];
        }

        //儲存被點擊的餐點
        public void SelectMeal(int whichButton)
        {
            int whichMeal = _page * BUTTONS + whichButton;
            _selectedMeal = _mealList[whichMeal];
        }

        //取得被點擊的餐點
        public Meal GetSelectedMeal()
        {
            return _selectedMeal;
        }

        //取得總金額資訊
        public String GetTotalPrice(int price)
        {
            int prices;
            _order.SetPrice(price);
            prices = _order.GetPrices();
            return TOTAL + prices.ToString() + UNIT;
        }

        //換頁
        public void ChangePage(int buttonIndex)
        {
            _page += buttonIndex - BASE;
        }

        //控制上一頁按鈕enable
        public bool EnablePreviousButton()
        {
            if (_page > 0)
                return true;
            else
                return false;
        }

        //控制下一頁按鈕enable
        public bool EnableNextButton()
        {
            if (_mealList.Count - (_page + 1) * BUTTONS > 0)
                return true;
            else
                return false;
        }

        //取得頁碼資訊
        public String GetPageInformation()
        {
            int totalPage;
            if (_mealList.Count % BUTTONS == 0)
                totalPage = _mealList.Count / BUTTONS;
            else
                totalPage = _mealList.Count / BUTTONS + 1;
            return PAGE + (_page + 1).ToString() + SLASH + totalPage.ToString();
        }

        //金額字串轉數值
        public int ChangeInteger(String price)
        {
            int integer = 0;
            const int TEN = 10;
            const Char ZERO = '0';
            for (int i = 0; i < price.Length; i++)
            {
                if (char.IsDigit(price[i]))
                    integer = integer * TEN + (price[i] - ZERO);
                else
                    break;
            }
            return integer;
        }

        //扣除金額
        public String SubtractPrice(String price)
        {
            int subtract = ChangeInteger(price) * (-1);
            return GetTotalPrice(subtract);
        }
    }
}