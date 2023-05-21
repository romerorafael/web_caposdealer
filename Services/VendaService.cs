using CD.Web.Context;
using CD.Web.Models;
using CD.Web.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CD.Web.Services
{
    public class VendaService
    {
        private VendaRepository _vendaRepository;

        public VendaService(ApiDbContext context)
        {
            _vendaRepository = new VendaRepository(context);
        }

        public async Task<bool> Add(Venda venda)
        {
            try
            {
                if (venda != null)
                {
                    return await _vendaRepository.Add(venda);
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

                return _vendaRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Venda> GetVendaById(int? id)
        {
            try
            {
                Venda company;

                if (id != null)
                {
                    company = await _vendaRepository.GetVendaById(id);
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

        public async Task<List<Venda>> GetVendaByClientId(int? id)
        {
            return await _vendaRepository.GetVendaByClientId(id);
        }

        public async Task<List<Venda>> GetVendaByProductId(int? id)
        {
            return await _vendaRepository.GetVendaByProductId(id);
        }

        public async Task<IEnumerable<Venda>> GetAll()
        {
            try
            {
                var companyList = await _vendaRepository.GetAll();

                return companyList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Venda venda)
        {
            try
            {
                if (venda != null)
                {
                    return await _vendaRepository.Update(venda);
                }
                else
                {
                    throw new Exception("Venda inexistente");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
