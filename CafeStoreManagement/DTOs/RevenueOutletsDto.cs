namespace CafeStoreManagement.DTOs
{
    public class RevenueOutletsDto
    {
        public Guid Id { get; set; }
        public Guid OutletId { get; set; }
        public string? OutletName { get; set; }
        public double? RevenuePerYear { get; set; }
        public string? Description { get; set; }
    }
}
