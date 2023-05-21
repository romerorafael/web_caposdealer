using CD.Web.Models;
using CD.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CD.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Produto> data = await _produtoService.GetAll();

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Produto data = await _produtoService.GetProdutoById(id);

                return data == null ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/create")]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            try
            {
                bool data = await _produtoService.Add(produto);

                return !data ? NotFound() : Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/put")]
        public async Task<IActionResult> Put([FromBody] Produto produto)
        {
            try
            {
                bool data = await _produtoService.Update(produto);

                return !data ? NotFound() : Ok( new { Success = true, Data = produto } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Produto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("[controller]/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool data = _produtoService.Delete(id);

                return !data ? NotFound() : Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
