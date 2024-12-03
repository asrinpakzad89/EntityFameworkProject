using Domain.Entities.Commons;
using Domain.Entities.Orders;
using Domain.Entities.Carts;

namespace Domain.Entities.Users;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<UserInRole> UserInRoles { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Cart> Carts { get; set; }
}
