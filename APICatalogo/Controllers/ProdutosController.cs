using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitofWork _uof;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitofWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutoPrecos()
        {
            var produtos = _uof.ProdutoRepositoy.GetProdutosPorPreco().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            return produtosDTO;
        }
        // GET: api/Produtos
        [HttpGet]
        public  ActionResult<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtos = _uof.ProdutoRepositoy.Get().ToList();
            var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
            return produtosDTO;
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public ActionResult<ProdutoDTO> GetProduto(int id)
        {
            var produto =  _uof.ProdutoRepositoy.GetbyId(p => p.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }
            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
            return produtoDTO;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            _uof.ProdutoRepositoy.Update(produto);
            _uof.Commit();

            return NoContent();
        }

        // POST: api/Produtos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Produto> PostProduto([FromBody] ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _uof.ProdutoRepositoy.Add(produto);
            _uof.Commit();

            var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

            return CreatedAtAction("GetProduto", new { id = produto.ProdutoId }, produtoDTO);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public ActionResult<ProdutoDTO> DeleteProduto(int id)
        {
            var produto = _uof.ProdutoRepositoy.GetbyId(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            _uof.ProdutoRepositoy.Delete(produto);
             _uof.Commit();

            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return produtoDto;
        }

    }
}
