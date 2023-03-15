namespace MeuEccomerce.API.Application.Models.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
        public string ImageUrl { get;  set; }
        public int Inventory { get;  set; }
        public int CategoryId { get;  set; }
    }
}
