using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEcommerce.Models
{
    [Table("Ordini")]
    public class Ordine
    {
        [Key]
        public long IdOrdine { get; set; }

        [Required]
        public DateTime? Data { get; set; }

           
        [Required, StringLength(30)]
        public string? TipoPagamento { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string? DettagliCarrello { get; set; }

        [ForeignKey(nameof(Cliente))]
        public string? FkCliente {  get; set; } 
        public Cliente? Cliente { get; set; }
        
        [Required,StringLength(30)]
        public string? IndirizzoFat { get; set; }
    }
}
