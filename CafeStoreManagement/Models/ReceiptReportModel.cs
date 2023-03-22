namespace CafeStoreWeb.Data
{
    public class ReceiptModel:BaseModel
    {
        public Guid ItemId { get; set; }
        public Guid ReceiptId { get; set; }
        public double UnitPrice { get; set; }
        public int Qty { get; set; }
        public double Total { get; set; }
        public Guid OutletId { get; set; }
        public Guid SizeId { get; set; }
        public string? Cashier { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
