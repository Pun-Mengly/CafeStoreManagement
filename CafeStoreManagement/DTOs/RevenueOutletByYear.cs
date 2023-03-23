namespace CafeStoreManagement.DTOs
{
    public class RevenueOutletByYear
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string? Outlet { get; set; }
        public double Revenue { get; set; }
    }
}
