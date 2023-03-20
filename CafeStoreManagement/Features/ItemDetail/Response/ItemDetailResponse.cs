namespace CafeStoreManagement.Features.ItemDetail.Response
{
    public class ItemDetailResponse
    {
        public Guid Id { get; set; }
        public int No { get; set; }
        public string ItemName { get; set; }
        public string OutletName { get; set; }
        public string itemCode { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public string Decription { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
