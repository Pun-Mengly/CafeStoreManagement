namespace CafeStoreManagement.Models;

public class OutletModel:BaseModel
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
    public bool IsDeleted { get; set; }
}
