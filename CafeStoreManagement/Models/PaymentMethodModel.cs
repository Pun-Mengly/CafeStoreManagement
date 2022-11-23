namespace CafeStoreManagement.Models
{
    public class PaymentMethodModel:BaseModel
    {
        public string  Code { get; set; }
        public string  Name { get; set; }
        public bool  IsDeleted { get; set; }
    }
}
