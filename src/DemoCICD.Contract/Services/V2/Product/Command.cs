using DemoCICD.Contract.Abstractions.Message;

namespace DemoCICD.Contract.Services.V2.Product;
public static class Command
{
    public record CreateProductCommand(
            string Name,
            decimal Price,
            string Description) : ICommand;

    public record UpdateProduct(
            Guid Id,
            string Name,
            decimal Price,
            string Description) : ICommand;

    public record DeleteProduct(Guid Id) : ICommand;
}
