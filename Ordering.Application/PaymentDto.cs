namespace Ordering.Application;

public record PaymentDto(string CardName, string CardNumber, string Expiration, string Cvv, int PaymentMethod);