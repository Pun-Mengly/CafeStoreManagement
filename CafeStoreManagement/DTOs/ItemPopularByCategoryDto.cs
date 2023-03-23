namespace CafeStoreManagement.DTOs
{
    public class ItemPopularByCategoryDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public ItemDto? Items { get; set; }
    }
    public class ItemDto
    {
        public int Top { get; set; }
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? Decription { get; set; }
        
    }  
}
