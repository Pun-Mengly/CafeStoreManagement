namespace CafeStoreManagement.Models
{
    public class ChannelModel:BaseModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Abv { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
