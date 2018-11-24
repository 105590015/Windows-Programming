namespace Homework
{
    class Order
    {
        private int _total;
        public Order()
        {
            _total = 0;
        }

        //加總金額
        public void SetPrice(int price)
        {
            _total += price;
        }

        //取得金額
        public int GetPrices()
        {
            return _total;
        }
    }
}
