namespace CafeStoreManagement.DTOs
{
    public class PopularItemDto
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public int Qty { get; set; }
        public string Photo { get; set; }
    }
}
