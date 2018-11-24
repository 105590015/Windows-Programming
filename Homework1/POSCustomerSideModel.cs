using System;
using System.Collections.Generic;

namespace Homework1
{
    class POSCustomerSideModel
    {
        private int _page = 0;
        private Meal _selectedMeal = null;
        private Order _order = new Order();
        private List<Meal> _mealList = new List<Meal>();
        const String PAGE = "Page：";
        const String SLASH = " / ";
        const String TOTAL = "Total：";
        const String UNIT = "元";
        const String MEAL1 = "大麥克";
        const String MEAL2 = "牛肉吉士堡";
        const String MEAL3 = "四盎司牛肉堡";
        const String MEAL4 = "培根牛肉堡";
        const String MEAL5 = "麥香魚";
        const String MEAL6 = "麥香雞";
        const String MEAL7 = "勁辣雞腿堡";
        const String MEAL8 = "板烤雞腿堡";
        const String MEAL9 = "起司豬排堡";
        const String MEAL10 = "大大雞腿堡";
        const String MEAL11 = "六塊麥克雞塊";
        const String MEAL12 = "千島黃金蝦堡";
        const String MEAL13 = "安格斯黑牛堡";
        const String MEAL14 = "嫩煎雞腿堡";
        const String MEAL15 = "辣脆雞腿堡";
        const int BUTTONS = 9;
        const int BASE = 10;
        const int PRICE49 = 49;
        const int PRICE53 = 53;
        const int PRICE59 = 59;
        const int PRICE69 = 69;
        const int PRICE79 = 79;
        const int PRICE99 = 99;
        const int PRICE109 = 109;
        // 建立基礎菜單
        public void CreateInitialMeals()
        {
            String[] meals = new String[]
            { MEAL1, MEAL2, MEAL3, MEAL4, MEAL5,
                MEAL6, MEAL7, MEAL8, MEAL9, MEAL10,
                MEAL11, MEAL12, MEAL13, MEAL14, MEAL15 };
            int[] prices = new int[]
            { PRICE69, PRICE59, PRICE79, PRICE99, PRICE49,
                PRICE49, PRICE69, PRICE79, PRICE53, PRICE53,
                PRICE59, PRICE69, PRICE109, PRICE109, PRICE109 };
            for (int i = 0; i < prices.Length; i++)
                _mealList.Add(new Meal(meals[i], prices[i]));
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
    }
}