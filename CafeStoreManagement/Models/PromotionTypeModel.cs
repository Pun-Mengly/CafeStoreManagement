namespace CafeStoreManagement.Models
{
    public class PromotionTypeModel:BaseModel
    {
        public string Code { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
