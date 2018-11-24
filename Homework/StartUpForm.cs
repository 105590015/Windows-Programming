using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class StartUpForm : Form
    {
        private Form _customerProgram;
        private Form _restaurantProgram;
        private Model _model = new Model();
        private StartUpFormPresentationModel _startUpFormPresentationModel = new StartUpFormPresentationModel();
        public StartUpForm()
        {
            InitializeComponent();
        }

        //更新按鈕狀態
        private void RefreshWidgetState()
        {
            _customerButton.Enabled = _startUpFormPresentationModel.IsCustomerButtonClicked();
            _restaurantButton.Enabled = _startUpFormPresentationModel.IsRestaurantButtonClicked();
        }

        //開啟客戶端並關閉客戶端按鈕
        private void OpenCustomerForm(object sender, EventArgs e)
        {
            _customerProgram = new POSCustomerSideForm(_model);
            _customerProgram.FormClosed += new FormClosedEventHandler(ResetCustomerButton);
            _customerProgram.Show();
            _startUpFormPresentationModel.ClickCustomerButton();
            RefreshWidgetState();
        }

        //開啟商家端並關閉商家端按鈕
        private void OpenRestaurantForm(object sender, EventArgs e)
        {
            _restaurantProgram = new POSRestaurantSideForm(_model);
            _restaurantProgram.FormClosed += new FormClosedEventHandler(ResetRestaurantButton);
            _restaurantProgram.Show();
            _startUpFormPresentationModel.ClickRestaurantButton();
            RefreshWidgetState();
        }

        //關閉系統
        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        //重設客戶端按鈕
        private void ResetCustomerButton(object sender, FormClosedEventArgs e)
        {
            _startUpFormPresentationModel.CloseCustomerForm();
            _model.ClearOrders();
            RefreshWidgetState();
        }

        //重設商家端按鈕
        private void ResetRestaurantButton(object sender, FormClosedEventArgs e)
        {
            _startUpFormPresentationModel.CloseRestaurantForm();
            RefreshWidgetState();
        }
    }
}
