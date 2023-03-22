namespace CafeStoreManagement.DTOs
{
    public class ReceiptDto:BaseModel
    {
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public Guid ReceiptId { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public Guid OutletId { get; set; }
        public string? OutletName { get; set; }
        public Guid SizeId { get; set; }
        public string? SizeName { get; set; }
        public string? CashierId { get; set; }
        public string? CashierName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
