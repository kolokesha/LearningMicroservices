namespace Ordering.Application;

public record OrderItemDto (Guid OrderId, Guid ProdcutId, int Quantity, decimal Price);