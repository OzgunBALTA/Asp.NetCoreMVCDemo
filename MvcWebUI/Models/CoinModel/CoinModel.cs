namespace MvcWebUI.Models.CoinModel
{
    public class CoinModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Current_price { get; set; }
        public decimal Price_change_24h { get; set; }
    }
}
