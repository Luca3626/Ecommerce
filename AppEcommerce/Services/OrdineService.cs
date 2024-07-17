using AppEcommerce.Models;
using AppEcommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppEcommerce.Services
{
    public class OrdineService : IOrdineRepository
    {
        private readonly DbContesto _dbContesto;

        public OrdineService(DbContesto dbContesto)
        {
            _dbContesto = dbContesto;
        }

        public List<DettaglioOrdine> LoadOrders(string username)
        {
          return  _dbContesto.Ordini.Include("Cliente").
                Where(ord => ord.Cliente!.Username == username).
                Select(ord => new DettaglioOrdine
            {
                IndirizzoFat = ord.IndirizzoFat,
                TipoPagamento = ord.TipoPagamento,
                Data = ord.Data,
                Cliente = ord.Cliente,
                DettagliCarrello = JsonConvert.DeserializeObject<Carrello>(ord.DettagliCarrello)

            }).ToList();
        }

        public void SaveOrdine(Ordine ordine)
        {
            _dbContesto.Ordini.Add(ordine);
            _dbContesto.SaveChanges();  
        }
    }
}
