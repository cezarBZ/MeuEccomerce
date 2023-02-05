namespace MeuEccomerce.API.Application.Models.DTO_s
{
    public class CategoryDTO
    {
        public CategoryDTO(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
