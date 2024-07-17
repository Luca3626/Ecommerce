using Microsoft.EntityFrameworkCore;

namespace AppEcommerce.Models
{
    public class DbContesto : DbContext
    {
        public DbContesto(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Prodotto> Prodotti {  get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
    }
}
