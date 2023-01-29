using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Informe o nome da imagem")]
        [MinLength(5)]
        [MaxLength(250)]
        public string ImageUrl { get; set; }
    }
}
