namespace CafeStoreManagement.Features
{
    public class ItemCommand
    {
        public Guid Id { get; set; }
        public Guid OutletId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
