namespace MeuEccomerce.API.Application.Models.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string name, string categoryName)
        {
            Name = name;
            CategoryName = categoryName;
        }

        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
