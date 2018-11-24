using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class StartUpFormPresentationModel
    {
        private bool _customerEnable;
        private bool _restaurantEnable;
        public StartUpFormPresentationModel()
        {
            _customerEnable = true;
            _restaurantEnable = true;
        }

        //取得客戶端按鈕狀態
        public bool IsCustomerButtonClicked()
        {
            return _customerEnable;
        }

        //取得商家端按鈕狀態
        public bool IsRestaurantButtonClicked()
        {
            return _restaurantEnable;
        }

        //觸發客戶端按鈕
        public void ClickCustomerButton()
        {
            _customerEnable = false;
        }

        //觸發商家端按鈕
        public void ClickRestaurantButton()
        {
            _restaurantEnable = false;
        }

        //關閉客戶端按鈕
        public void CloseCustomerForm()
        {
            _customerEnable = true;
        }

        //觸發商家端按鈕
        public void CloseRestaurantForm()
        {
            _restaurantEnable = true;
        }
    }
}
