using AppEcommerce.Models;

namespace AppEcommerce.Repositories
{
    public interface IAutenticaRepository
    {
        public void SaveClient(Cliente cliente);
        public Cliente GetClient(string username,string pwd);
        public Cliente GetClientByUsername(string username);
    }
}
