namespace CafeStoreManagement.Models
{
    public class SizeModel:BaseModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
