namespace MSTest.OnlineTradingApp.Models
{
    public class StockViewModel
    {
        public int Id { get; set; }
        public int TransactionType { get; set; }
        public int CustomerId { get; set; }
        public int StockId { get; set; }
        public int StockCount { get; set; }
        public int Status { get; set; }
    }
}