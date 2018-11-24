using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Homework
{
    public partial class POSCustomerSideForm : Form
    {
        private CustomerFormPresentationModel _customerFormPresentationModel = new CustomerFormPresentationModel();
        private Model _model;
        private List<Button> _buttonList = new List<Button>();
        private String _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        const String END = "\r\n";
        const String UNIT = "元";
        const int BUTTONS = 9;
        const int ROW = 3;
        const int COLUMN = 3;
        public POSCustomerSideForm()
        {
            InitializeComponent();
            _model = _customerFormPresentationModel.GetModel();
            _model.CreateInitialMeals();
            _pageLabel.Text = _model.GetPageInformation();
            CreateButton();
        }

        //創建按鈕
        private void CreateButton()
        {
            int[] buttonLocationX = new int[] { 6, 100, 193 };
            int[] buttonLocationY = new int[] { 21, 106, 191 };
            for (int i = 0; i < BUTTONS; i++)
            {
                Button button = new Button();
                Meal meal = _model.GetMealList()[i];
                button.Text = meal.GetName() + END + meal.GetPrice() + UNIT;
                button.Font = new Font("Microsoft JhengHei", 9F);
                button.TextAlign = ContentAlignment.BottomLeft;
                button.BackgroundImage = Image.FromFile(_projectPath + meal.GetImageRelativePath());
                button.Size = new Size(90, 81);
                button.Location = new Point(buttonLocationX[i % COLUMN], buttonLocationY[i / ROW]);
                button.TabIndex = i;
                button.Click += ClickMenuButton;
                _buttonList.Add(button);
                _mealGroupBox.Controls.Add(button);
            }
        }

        //重設按鈕狀態
        private void RefreshWidgetState()
        {
            _nextButton.Enabled = _customerFormPresentationModel.IsNextEnable();
            _previousButton.Enabled = _customerFormPresentationModel.IsPreviousEnable();
            _addButton.Enabled = _customerFormPresentationModel.IsAddEnable();
        }

        //餐點按鈕被觸發
        private void ClickMenuButton(object sender, EventArgs e)
        {
            _model.SelectMeal(((Button)(sender)).TabIndex);
            _describeBox.Text = _model.GetSelectedMeal().GetDescribe();
            _customerFormPresentationModel.PrepareAdd();
            RefreshWidgetState();
        }

        //加點按鈕被觸發
        private void ClickAddButton(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = _checkDataGridView.Rows;
            Meal meal = _model.GetSelectedMeal();
            String mealName;
            int mealPrice;
            mealName = meal.GetName();
            mealPrice = meal.GetPrice();
            rows.Add(new Object[] { null, mealName, mealPrice.ToString() + UNIT });
            _totalPriceLabel.Text = _model.GetTotalPrice(mealPrice);
            _customerFormPresentationModel.ResetAdd();
            RefreshWidgetState();
        }

        //換頁按鈕被觸發
        private void ClickChangedPageButton(object sender, EventArgs e)
        {
            _model.ChangePage(((Button)(sender)).TabIndex);
            _pageLabel.Text = _model.GetPageInformation();
            _customerFormPresentationModel.ResetAdd();
            _customerFormPresentationModel.TurnPage();
            ResetMealButton();
            RefreshWidgetState();
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
                    _buttonList[i].BackgroundImage = Image.FromFile(_projectPath + meal.GetImageRelativePath());
                    _buttonList[i].Visible = true;
                }
                catch
                {
                    _buttonList[i].Visible = false;
                }
            }
        }

        //點擊刪除資料
        private void ClickDelete(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                String price = _checkDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                _totalPriceLabel.Text = _model.SubtractPrice(price);
                _checkDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}