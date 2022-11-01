namespace CafeStoreManagement.Models
{
    public class ItemDetailModel:BaseModel
    {
        public Guid ItemId { get; set; }
        public Guid SizeId { get; set; }
        public Guid CategortId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
