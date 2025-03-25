using System.ComponentModel.DataAnnotations;


namespace ToyStore_API.Models
{
    public class Toys
    {
        public int Id_toy { get; set; }

        [Required]
        public string Name_toy { get; set; }

        [Required]
        public string Type_toy { get; set; }

        [Required]
        [Range(0, 12, ErrorMessage = "Classificação do brinquedo deve ser entre 0 e 12 anos.")]
        public int Classification_toy { get; set; }

        [Required]
        public string Brand_toy { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que 0.")]
        public decimal Price_toy { get; set; }
    }
}
