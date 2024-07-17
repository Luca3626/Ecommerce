using AppEcommerce.Models;
using System.Collections;

namespace AppEcommerce.Repositories
{
    public interface IProdottoRepository
    {
        public IEnumerable GetProducts();
        public Prodotto? GetProduct(long id_prod);
    }
}
