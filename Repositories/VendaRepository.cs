using CD.Web.Context;
using CD.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CD.Web.Repositories
{
    public class VendaRepository
    {
        private ApiDbContext _dbContext;

        public VendaRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Venda>> GetAll()
        {
            return await _dbContext.Vendas.ToListAsync();
        }
        public async Task<Venda> GetVendaById(int? id)
        {
            return await _dbContext.Vendas.FindAsync(id);
        }
        public async Task<bool> Add(Venda Venda)
        {
            try
            {
                _dbContext.Vendas.Add(Venda);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(Venda Venda)
        {

            try
            {
                _dbContext.Vendas.Update(Venda);
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
                var Venda = _dbContext.Vendas.Where(d => d.IdVenda == id).FirstOrDefault();
                if (Venda != null)
                {
                    _dbContext.Vendas.Remove(Venda);
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
