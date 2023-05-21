using CD.Web.Models;
using CD.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CD.Web.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaService _vendaService;
        private readonly ProdutoService _produtoService;
        private readonly ClienteService _clienteService;

        public VendaController(VendaService vendaService, ClienteService clienteService, ProdutoService produtoService)
        {
            _vendaService = vendaService;
            _clienteService = clienteService;
            _produtoService = produtoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Cliente cliente = new Cliente();
                Produto produto = new Produto();

                IEnumerable<Venda> data = await _vendaService.GetAll();
                if (data != null)
                {
                    foreach (Venda v in data)
                    {
                        cliente = await _clienteService.GetClienteById(v.IdCliente);
                        produto = await _produtoService.GetProdutoById(v.IdProduto);

                        v.nmCliente = cliente.NmCliente;
                        v.dscProduto = produto.DscProduto;
                        v.VlrUnitario = produto.VlrUnitario;
                    }
                }

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Venda data = await _vendaService.GetVendaById(id);
                var cliente = await _clienteService.GetClienteById(data.IdCliente);
                var produto = await _produtoService.GetProdutoById(data.IdProduto);

                data.nmCliente = cliente.NmCliente;
                data.dscProduto = produto.DscProduto;
                data.VlrUnitario= produto.VlrUnitario;

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/create")]
        public async Task<IActionResult> Post([FromBody] Venda venda)
        {
            try
            {
                venda.VlrUnitarioVenda = venda.QtdVenda * venda.VlrUnitario;
                venda.DthVenda = DateTime.Now;

                bool data = await _vendaService.Add(venda);

                return !data ? NotFound() : Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/put")]
        public async Task<IActionResult> Put([FromBody] Venda venda)
        {
            try
            {
                venda.VlrUnitarioVenda = venda.QtdVenda * venda.VlrUnitario;
                venda.DthVenda = DateTime.Now;
                bool data = await _vendaService.Update(venda);

                return !data ? NotFound() : Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venda))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool data = _vendaService.Delete(id);

                return !data ? NotFound() : Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
