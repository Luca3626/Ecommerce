using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEcommerce.Models
{
    [Table("Categorie")]
    public class Categoria
    {

        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
        public string? Nome { get; set; }
        
    }
}
