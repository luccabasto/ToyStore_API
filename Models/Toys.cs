using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ToyStore_API.Models
{
    [Table("TB_TOYS")]
    public class Toys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_toy { get; set; }

        [Required]
        [StringLength(100)]
        public string Name_toy { get; set; }

        [Required]
        [StringLength(50)]
        public string Type_toy { get; set; }

        [Required] 
        [Range(0, 12, ErrorMessage = "Classificação do brinquedo deve ser entre 0 e 12 anos.")]
        public int Classification_toy { get; set; }

        [Required]
        [StringLength(10)]
        public string Brand_toy { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que 0.")]
        public decimal Price_toy { get; set; }
    }
}
