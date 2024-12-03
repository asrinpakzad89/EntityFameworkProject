using Domain.Entities.Commons;

namespace Domain.Entities.Users;
public class Role: BaseEntity
{
    public string Name { get; set; }
    public ICollection<UserInRole> UserInRoles { get; set; }
}
