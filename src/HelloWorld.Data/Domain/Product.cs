using System;

namespace HelloWorld.Data.Domain
{
    public class Product
    {
        public Product()
        {
            DateCreated = DateTimeOffset.UtcNow;
        }

        public Product(string name, string description, decimal retailPrice) : this()
        {
            Name = name;
            Description = description;
            RetailPrice = retailPrice;
        }

        public int Id { get; private set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
