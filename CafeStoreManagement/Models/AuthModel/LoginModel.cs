

using System.ComponentModel.DataAnnotations;

public class LoginModel
    {
     [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }   
    }
public class RoleModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
public class UserRoleModel
{
    public Guid UserId { get; set; }
    //public Guid RoleId { get; set; }
    public ICollection<ListRoleId>? RoleIds { get; set; }
}
public class ListRoleId
{
    public Guid RoleId { get; set; }
}

