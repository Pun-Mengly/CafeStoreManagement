namespace CafeStoreWeb.Data
{
    public class ReceiptReportModel
    {
        public Guid ReceiptId { get; set; }
        public Guid ItemId { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }
        public string? Cashier { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
