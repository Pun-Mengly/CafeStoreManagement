namespace CafeStoreManagement.Models
{
    public class SaleModel:BaseModel
    {
        public Guid ItemDetailId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid PromotionId { get; set; }
        public Guid TaxId { get; set; }
        public Guid CustomerInfo { get; set; }
    }
}
