using CD.Web.Context;
using CD.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CD.Web.Repositories
{
    public class ProdutoRepository
    {
        private ApiDbContext _dbContext;

        public ProdutoRepository(ApiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoById(int? id)
        {
            return await _dbContext.Produtos.FindAsync(id);
        }

        public async Task<bool> Add(Produto Produto)
        {
            try
            {
                _dbContext.Produtos.Add(Produto);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(Produto Produto)
        {

            try
            {
                _dbContext.Produtos.Update(Produto);
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
                var Produto = _dbContext.Produtos.Where(d => d.IdProduto == id).FirstOrDefault();
                if (Produto != null)
                {
                    _dbContext.Produtos.Remove(Produto);
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
