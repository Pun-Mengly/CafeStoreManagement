namespace CafeStoreManagement.Features
{
    public class ItemDetailCommand
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string itemCode { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Photo { get; set; }
        public string Decription { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
