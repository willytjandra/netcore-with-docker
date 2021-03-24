namespace HelloWorld.Api.Models
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
    }
}
