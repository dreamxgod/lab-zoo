namespace ZooShop.Models;
public class Order
{
    public int Id { get; set; }
    public DateTime Placed { get; set; }
    public Pet OrderItem { get; set; }
    public int OrderItemId { get; set; }
    public decimal Total { get; set; }
}

