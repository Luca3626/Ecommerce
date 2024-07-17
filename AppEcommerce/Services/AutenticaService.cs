using AppEcommerce.Models;
using AppEcommerce.Repositories;

namespace AppEcommerce.Services
{
    public class AutenticaService : IAutenticaRepository
    {
        private readonly DbContesto _dbContesto;

        public AutenticaService(DbContesto dbContesto)
        {
            _dbContesto = dbContesto;
        }

        public Cliente GetClient(string username, string pwd)
        {
            Cliente c= _dbContesto.Clienti.ToList().
                FirstOrDefault(c => c.Username.Equals(username) && c.Password.Equals(pwd), null);
                
            return c;
        }

        public Cliente GetClientByUsername(string username)
        {
            return _dbContesto.Clienti.Find(username);  
        }

        public void SaveClient(Cliente cliente)
        {
            _dbContesto.Clienti.Add(cliente);
            _dbContesto.SaveChanges();
        }

    }
}
