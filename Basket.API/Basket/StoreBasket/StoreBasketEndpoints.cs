using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest(ShoppingCart Cart);

public record StoreBasketResponse(string UserName);

public class StoreBasketEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketRequest>();
            
            var result = await sender.Send(command);
            
            var response = result.Adapt<StoreBasketResponse>();
            
            return Results.Created($"/basket/{response.UserName}", response);
        })
        .WithName("CreateProduct")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By ID")
        .WithDescription("Get product by ID");
    }
}