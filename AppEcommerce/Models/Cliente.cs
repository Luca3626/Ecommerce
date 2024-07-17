using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEcommerce.Models
{
    [Table("Clienti")]
    public class Cliente
    {
        [Key]
        [Required]
        [StringLength(30)]
        public string? Username { get; set; }

        [Required]
        [StringLength(30)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string? Cognome { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(8)]
        public string? Password { get; set; }

        [Required,StringLength(40)]
        public string? Indirizzo { get; set; }   

          
    }
}
