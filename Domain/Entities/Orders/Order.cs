using Domain.Entities.Commons;
using Domain.Entities.Orders;
using Domain.Entities.Users;

namespace Domain.Entities.Orders;

public class Order : BaseEntity
{
    public virtual User User { get; set; }
    public long UserId { get; set; }

    //public virtual RequestPay RequestPay { get; set; }
    //public long RequestPayId { get; set; }

    public OrderState OrderState { get; set; }

    public string Address { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
