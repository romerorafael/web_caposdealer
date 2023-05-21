using CD.Web.Context;
using CD.Web.Models;
using CD.Web.Repositories;

namespace CD.Web.Services
{
    public class ProdutoService
    {
        private ProdutoRepository _produtoRepository;

       public ProdutoService(ApiDbContext context) {
            _produtoRepository = new ProdutoRepository(context);
        }

        public async Task<bool> Add(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    return await _produtoRepository.Add(produto);
                }
                else
                {
                    throw new Exception("Dados vazios");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool Delete(int id)
        {
            try
            {

                return _produtoRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Produto> GetProdutoById(int? id)
        {
            try
            {
                Produto company;

                if (id != null)
                {
                    company = await _produtoRepository.GetProdutoById(id);
                }
                else
                {
                    throw new Exception("Impossível fazer busca com id nulo");
                }

                return company;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            try
            {
                var companyList = await _produtoRepository.GetAll();

                return companyList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Produto produto)
        {
            try
            {
                if (produto != null)
                {
                    return await _produtoRepository.Update(produto);
                }
                else
                {
                    throw new Exception("Produto inexistente");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
