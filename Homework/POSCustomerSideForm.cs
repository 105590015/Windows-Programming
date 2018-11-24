using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Homework
{
    public partial class POSCustomerSideForm : Form
    {
        private CustomerFormPresentationModel _customerFormPresentationModel;
        private List<List<Button>> _buttonsList = new List<List<Button>>();
        const string END = "\r\n";
        const string ENABLE = "Enabled";
        const string TEXT = "Text";
        const int BUTTONS = 9;
        const int ROW = 3;
        const int COLUMN = 3;
        public POSCustomerSideForm(Model model)
        {
            InitializeComponent();
            _customerFormPresentationModel = new CustomerFormPresentationModel(model);
            _customerFormPresentationModel.GetModel().ModelChanged += UpdateView;
            _customerFormPresentationModel.GetModel().NotifyObserver();
            _nextButton.DataBindings.Add(ENABLE, _customerFormPresentationModel, "NextEnable");
            _previousButton.DataBindings.Add(ENABLE, _customerFormPresentationModel, "PreviousEnable");
            _addButton.DataBindings.Add(ENABLE, _customerFormPresentationModel, "AddEnable");
            _checkDataGridView.DataSource = _customerFormPresentationModel.GetModel().OrdersList;
            _pageLabel.Text = _customerFormPresentationModel.GetModel().GetComputeModel().GetPageInformation();
        }

        //創建對應tabpage的按鈕列表
        private List<Button> CreateButtonList(TabPage tabPage)
        {
            List<Button> buttons = new List<Button>();
            int[] buttonLocationX = new int[] { 4, 99, 194 };
            int[] buttonLocationY = new int[] { 5, 90, 175 };
            for (int i = 0; i < BUTTONS; i++)
            {
                Button button = CreateButton();
                button.Location = new Point(buttonLocationX[i % COLUMN], buttonLocationY[i / ROW]);
                buttons.Add(button);
                tabPage.Controls.Add(button);
            }
            return buttons;
        }

        //建立基礎按鈕
        private Button CreateButton()
        {
            Button button = new Button()
            { 
                Font = new Font("Microsoft JhengHei", 9F),
                TextAlign = ContentAlignment.BottomLeft,
                Size = new Size(90, 81) };
            button.Click += ClickMenuButton;
            return button;
        }

        //餐點按鈕被觸發
        private void ClickMenuButton(object sender, EventArgs e)
        {
            _customerFormPresentationModel.ChangeMeal(((Button)(sender)).TabIndex);
            _descriptionBox.Text = _customerFormPresentationModel.GetDescriptionText();
        }

        //加點按鈕被觸發
        private void ClickAddButton(object sender, EventArgs e)
        {
            _customerFormPresentationModel.AddMeal();
            BindingManager.Position = BindingManager.Count - 1;
        }

        //換頁按鈕被觸發
        private void ClickChangedPageButton(object sender, EventArgs e)
        {
            _customerFormPresentationModel.TurnPage(((Button)(sender)).TabIndex);
            ResetMealButton(_tabControl.SelectedIndex);
            _pageLabel.Text = _customerFormPresentationModel.GetModel().GetComputeModel().GetPageInformation();
        }

        //點擊刪除資料
        private void ClickDelete(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
                _customerFormPresentationModel.GetModel().DeleteOrder(BindingManager.Position);
        }

        //餐點類別轉換
        private void ChangeTabPage(object sender, EventArgs e)
        {
            _customerFormPresentationModel.ChangeCategory(_tabControl.SelectedIndex);
            ResetMealButton(_tabControl.SelectedIndex);
            _pageLabel.Text = _customerFormPresentationModel.GetModel().GetComputeModel().GetPageInformation();
        }

        //重設tabpage
        private void ResetTabPage(BindingList<Category> categoriesList)
        {
            _tabControl.Controls.Clear();
            _buttonsList.Clear();
            for (int i = 0; i < categoriesList.Count; i++)
            {
                TabPage tabPage = new TabPage()
                { 
                    Text = categoriesList[i].Name };
                _tabControl.Controls.Add(tabPage);
                _buttonsList.Add(CreateButtonList(tabPage));
                ResetMealButton(_tabControl.SelectedIndex);
            }
        }

        //重設菜單按鈕資料
        private void ResetMealButton(int index)
        {
            if (index >= 0)
            {
                string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                _customerFormPresentationModel.RefreshButtonInformation(index);
                List<string> buttonPresentationText = _customerFormPresentationModel.GetButtonPresentationText();
                List<string> buttonPresentationImagePath = _customerFormPresentationModel.GetButtonPresentationImagePath();
                List<bool> buttonVisible = _customerFormPresentationModel.GetButtonVisible();
                for (int i = 0; i < BUTTONS && i < _buttonsList[index].Count; i++)
                {
                    _buttonsList[index][i].Text = buttonPresentationText[i];
                    _buttonsList[index][i].BackgroundImage = Image.FromFile(projectPath + buttonPresentationImagePath[i]);
                    _buttonsList[index][i].Visible = buttonVisible[i];
                }
            }
        }

        //刷新總價
        private void RefreshTotalPrice(object sender, EventArgs e)
        {
            _totalPriceLabel.Text = _customerFormPresentationModel.GetModel().GetTotalPriceInformation();
        }

        //更新畫面
        private void UpdateView()
        {
            BindingList<Category> categoriesList = _customerFormPresentationModel.GetModel().CategoriesList;
            if (categoriesList.Count != _tabControl.Controls.Count)
                ResetTabPage(categoriesList);
            else
                ResetMealButton(_tabControl.SelectedIndex);
            _customerFormPresentationModel.ClearMeal();
            _descriptionBox.Text = _customerFormPresentationModel.GetDescriptionText();
            _customerFormPresentationModel.ChangeCategory(_tabControl.SelectedIndex);
            _pageLabel.Text = _customerFormPresentationModel.GetModel().GetComputeModel().GetPageInformation();
        }

        //資料連結管理
        private BindingManagerBase BindingManager
        {
            get
            {
                return BindingContext[_customerFormPresentationModel.GetModel().OrdersList];
            }
        }
    }
}