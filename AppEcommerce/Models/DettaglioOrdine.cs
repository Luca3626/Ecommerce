using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppEcommerce.Models
{
    public class DettaglioOrdine
    {
        public DateTime? Data { get; set; }
        public string? TipoPagamento { get; set; }

        public Carrello? DettagliCarrello { get; set; }
        public string? IndirizzoFat { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
