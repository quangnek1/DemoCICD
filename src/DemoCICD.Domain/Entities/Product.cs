using DemoCICD.Domain.Abstractions.Entities;

namespace DemoCICD.Domain.Entities;
public class Product : DomainEntity<Guid>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public static Product CreateProduct(Guid id, string name, decimal price, string description)
    {
        return new Product(id, name, price, description);
    }

    public Product(Guid id, string name, decimal price, string description)
    {
        //if (!NameValidation(name))
        //    throw new ArgumentNullException();
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }

    public void Update(string name, decimal price, string description)
    {
        //if (!NameValidation(name))
        //    throw new ArgumentNullException();

        Name = name;
        Price = price;
        Description = description;
    }

    private bool NameValidation(string name)
        => name.Contains("ABCD-");
}
