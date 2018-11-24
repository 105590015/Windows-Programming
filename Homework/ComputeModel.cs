using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Homework
{
    public class ComputeModel
    {
        private int _page;
        private int _totalPage;
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

        //判斷刪除餐點按鈕enable
        public bool JudgeDeleteMealEnable(Meal meal, BindingList<Order> ordersList)
        {
            bool deleteMealEnable = true;
            for (int i = 0; i < ordersList.Count; i++)
            {
                if (ordersList[i].Name == meal.Name)
                {
                    deleteMealEnable = false;
                    break;
                }
            }
            return deleteMealEnable;
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

        //讀取圖片位子
        public string BrowseImagePath()
        {
            const string FILTER = "Image|*.png;*.jpg;*.jpeg";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            openFileDialog.InitialDirectory = path;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = FILTER;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
                return TransformRelativePath(openFileDialog.FileName);
            else
                return "";
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
    }
}
