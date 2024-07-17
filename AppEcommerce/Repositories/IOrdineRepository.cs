using AppEcommerce.Models;

namespace AppEcommerce.Repositories
{
    public interface IOrdineRepository
    {
        public void SaveOrdine(Ordine ordine);
        public List<DettaglioOrdine> LoadOrders(string username);
    }
}
