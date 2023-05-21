using CD.Web.Context;
using CD.Web.Models;
using CD.Web.Repositories;

namespace CD.Web.Services
{
    public class ClienteService
    {
        private ClienteRepository _clienteRepository;

        public ClienteService(ApiDbContext context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<bool> Add(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    return await _clienteRepository.Add(cliente);
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

                return _clienteRepository.Delete(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Cliente> GetClienteById(int? id)
        {
            try
            {
                Cliente company;

                if (id != null)
                {
                    company = await _clienteRepository.GetClienteById(id);
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

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            try
            {
                var companyList = await _clienteRepository.GetAll();

                return companyList;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Update(Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    return await _clienteRepository.Update(cliente);
                }
                else
                {
                    throw new Exception("Cliente inexistente");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
