using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class CustomerFormPresentationModel
    {
        private Model _model = new Model();
        private bool _nextEnable;
        private bool _previousEnable;
        private bool _addEnable;
        public CustomerFormPresentationModel()
        {
            _nextEnable = true;
            _previousEnable = false;
            _addEnable = false;
        }

        //回傳Model
        public Model GetModel()
        {
            return _model;
        }

        //回傳下一頁按鈕狀態
        public bool IsNextEnable()
        {
            return _nextEnable;
        }

        //回傳上一頁按鈕狀態
        public bool IsPreviousEnable()
        {
            return _previousEnable;
        }

        //回傳加點按鈕狀態
        public bool IsAddEnable()
        {
            return _addEnable;
        }

        //已經準備加點商品
        public void PrepareAdd()
        {
            _addEnable = true;
        }

        //重設加入按鈕
        public void ResetAdd()
        {
            _addEnable = false;
        }

        //換頁
        public void TurnPage()
        {
            _nextEnable = _model.EnableNextButton();
            _previousEnable = _model.EnablePreviousButton();
        }
    }
}
