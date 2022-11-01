namespace CafeStoreManagement.Models
{
    public class CategoryModel:BaseModel
    {
        public Guid MenuGroupId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
