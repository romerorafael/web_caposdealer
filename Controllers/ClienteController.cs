using CD.Web.Models;
using CD.Web.Services;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CD.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;
        private readonly VendaService _vendaService;

        public ClienteController(VendaService vendaService, ClienteService clienteService)
        {
            _clienteService = clienteService;
            _vendaService = vendaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Cliente> data = await _clienteService.GetAll();

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Cliente data = await _clienteService.GetClienteById(id);

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/create")]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                bool data = await _clienteService.Add(cliente);

                return !data ? NotFound() : Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/put")]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {
                bool data = await _clienteService.Update(cliente);

                return !data ? NotFound() : Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vendas = await _vendaService.GetVendaByClientId(id);
                if(vendas != null)
                {
                    foreach (var venda in vendas)
                    {
                        _vendaService.Delete(venda.IdVenda);
                    }
                }
                bool data = _clienteService.Delete(id);

                return !data ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
