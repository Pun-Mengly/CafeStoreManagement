namespace CafeStoreManagement.Models
{
    public class PromotionModel:BaseModel
    {
        public Guid PromotionTypeId { get; set; }
        public string Name { get; set; }
        public double EffectionPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
