namespace BusinessLogic.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int EventId { get; set; }
    public int Qty { get; set; }
}