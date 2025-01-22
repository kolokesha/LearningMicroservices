using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.GetBasket;

/*public record GetBasketRequest(string UserName);*/
public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            
            var res = result.Adapt<GetBasketResponse>();
            
            return Results.Ok(res);
        })
        .WithName("Get basket")
        .Produces<GetBasketResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By ID")
        .WithDescription("Get product by ID");
    }
}