using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Homework1
{
    public partial class POSCustomerSideForm : Form
    {
        private POSCustomerSideModel _model = new POSCustomerSideModel();
        private List<Button> _buttonList = new List<Button>();
        private int[] _buttonLocationX = new int[] { 6, 100, 193 };
        private int[] _buttonLocationY = new int[] { 21, 120, 219 };
        const String END = "\r\n";
        const String UNIT = "元";
        const int BUTTONS = 9;
        const int ROW = 3;
        const int COLUMN = 3;
        public POSCustomerSideForm()
        {

            InitializeComponent();
            _model.CreateInitialMeals();
            _label1.Text = _model.GetPageInformation();
            for (int i = 0; i < BUTTONS; i++)
            {
                Button button = new Button();
                Meal meal = _model.GetMealList()[i];
                button.Text = meal.GetName() + END + meal.GetPrice() + UNIT;
                button.Font = new Font("Microsoft JhengHei", 9F);
                button.Size = new Size(90, 95);
                button.Location = new Point(_buttonLocationX[i % COLUMN], _buttonLocationY[i / ROW]);
                button.TabIndex = i;
                button.Click += ClickMenuButton;
                _buttonList.Add(button);
                _groupBox1.Controls.Add(button);
            }
        }

        //餐點按鈕被觸發
        private void ClickMenuButton(object sender, EventArgs e)
        {
            _model.SelectMeal(((Button)(sender)).TabIndex);
            _button12.Enabled = true;
        }

        //加點按鈕被觸發
        private void ClickAddButton(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = _dataGridView1.Rows;
            Meal meal = _model.GetSelectedMeal();
            String mealName;
            int mealPrice;
            mealName = meal.GetName();
            mealPrice = meal.GetPrice();
            rows.Add(new Object[] { mealName, mealPrice.ToString() + UNIT });
            _label2.Text = _model.GetTotalPrice(mealPrice);
        }

        //換頁按鈕被觸發
        private void ClickChangedPageButton(object sender, EventArgs e)
        {
            _model.ChangePage(((Button)(sender)).TabIndex);
            ResetMealButton();
            _button10.Enabled = _model.EnablePreviousButton();
            _button11.Enabled = _model.EnableNextButton();
            _label1.Text = _model.GetPageInformation();
        }

        //重設菜單按鈕資料
        private void ResetMealButton()
        {
            for (int i = 0; i < BUTTONS; i++)
            {
                try
                {
                    Meal meal = _model.GetMeal(i);
                    _buttonList[i].Text = meal.GetName() + END + meal.GetPrice() + UNIT;
                    _buttonList[i].Visible = true;
                }
                catch
                {
                    _buttonList[i].Visible = false;
                }
            }
        }
    }
}