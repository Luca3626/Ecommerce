using AppEcommerce.Models;
using AppEcommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AppEcommerce.Services
{
    public class ProdottoService : IProdottoRepository
    {
        private readonly DbContesto _dbContesto;

        public ProdottoService(DbContesto dbContesto)
        {
            _dbContesto = dbContesto;
        }

        public IEnumerable GetProducts()
        {
            return _dbContesto.Prodotti.ToList();
        }
        public Prodotto? GetProduct(long id_prod)
        {
            return _dbContesto.Prodotti.Find(id_prod);
        }
    }
}
