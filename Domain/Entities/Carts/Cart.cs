using Domain.Entities.Commons;
using Domain.Entities.Users;

namespace Domain.Entities.Carts;

public class Cart : BaseEntity
{
    public virtual User User { get; set; }
    public long? UserId { get; set; }

    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
