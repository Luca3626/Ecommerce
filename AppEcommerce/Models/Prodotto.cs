using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEcommerce.Models
{
    [Table("Prodotti")]
    public class Prodotto
    {
        [Key]
        public long IdProdotto { get; set; }
        [StringLength(50)]
        public string? Nome { get; set; }
        [Required]
        public int? Quantita { get; set; }
        [Required]
        public double Prezzo { get; set; }

        [ForeignKey(nameof(Categoria))]    
        public int FkCategoria { get; set; }    
        public Categoria? Categoria { get; set; }

        [Required,StringLength(150)]  
        public string? Img { get; set; }

        [Required,StringLength(200)]  
        public string? Descrizione { get; set; }
     
      
    }
}
