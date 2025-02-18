using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers => new List<Customer>()
    {
        Customer.Create(CustomerId.Of(new Guid("DD59E57E-1351-49D7-ABE1-9D44136CDF7E")), "alex", "alex@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("9E88F1F7-2F64-43B7-B063-A5352CD69DD1")), "maria", "maria@yandex.ru"),
    };
    
    public static IEnumerable<Product> Products => new List<Product>()
    {
        Product.Create(ProductId.Of(new Guid("E1A947AA-BF20-4DEE-BB94-706DFDE5FDE9")), "Iphone 15", 2000),
        Product.Create(ProductId.Of(new Guid("0B9DA6FA-02C7-4E47-A051-C047B7499EFC")), "Iphone 14 pro", 1300),
    };
    
    public static IEnumerable<Order> OrderWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("9E88F1F7-2F64-43B7-B063-A5352CD69DD1")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1, OrderStatus.Draft);
            order1.Add(ProductId.Of(new Guid("E1A947AA-BF20-4DEE-BB94-706DFDE5FDE9")), 2, 500);
            order1.Add(ProductId.Of(new Guid("0B9DA6FA-02C7-4E47-A051-C047B7499EFC")), 1, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("DD59E57E-1351-49D7-ABE1-9D44136CDF7E")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2, OrderStatus.Draft);
            order2.Add(ProductId.Of(new Guid("E1A947AA-BF20-4DEE-BB94-706DFDE5FDE9")), 1, 650);
            order2.Add(ProductId.Of(new Guid("E1A947AA-BF20-4DEE-BB94-706DFDE5FDE9")), 2, 450);

            return new List<Order> { order1, order2 };
        }
    }
}