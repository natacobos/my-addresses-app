using Microsoft.EntityFrameworkCore;

namespace Addresses.Api.Data;

public class Address
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Label { get; set; } = "";
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public bool IsDefault { get; set; }
}

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses => Set<Address>();

    public void Seed()
    {
        if (Addresses.Any()) return;
        Addresses.AddRange(
            new Address { Id = 1, CustomerId = 1, Label = "Home", Street = "742 Evergreen Terrace", City = "Springfield", IsDefault = true },
            new Address { Id = 2, CustomerId = 1, Label = "Office", Street = "100 Main Street", City = "Springfield" },
            new Address { Id = 3, CustomerId = 1, Label = "Parents", Street = "12 Oak Avenue", City = "Shelbyville" },
            new Address { Id = 4, CustomerId = 2, Label = "Home", Street = "31 Spooner Street", City = "Quahog", IsDefault = true },
            new Address { Id = 5, CustomerId = 2, Label = "Work", Street = "8 Harbor Road", City = "Quahog" });
        SaveChanges();
    }
}
