using CD.Web.Context;
using CD.Web.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CD.Web.Repositories
{
    public class ClienteRepository
    {
        private ApiDbContext _dbContext;

        public ClienteRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int? id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<bool> Add(Cliente Cliente)
        {
            try
            {
                _dbContext.Clientes.Add(Cliente);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(Cliente Cliente)
        {

            try
            {
                _dbContext.Clientes.Update(Cliente);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool Delete(int id)
        {
            try
            {
                var Cliente = _dbContext.Clientes.Where(d => d.IdCliente == id).FirstOrDefault();
                if (Cliente != null)
                {
                    _dbContext.Clientes.Remove(Cliente);
                    _dbContext.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
