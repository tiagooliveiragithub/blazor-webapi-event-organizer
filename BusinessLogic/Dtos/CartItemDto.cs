namespace BusinessLogic.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int CartId { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int Qty { get; set; }

}