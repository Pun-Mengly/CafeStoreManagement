namespace CafeStoreManagement.Models
{
    public class TaxModel:BaseModel
    {
        public string Code { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Percentage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
