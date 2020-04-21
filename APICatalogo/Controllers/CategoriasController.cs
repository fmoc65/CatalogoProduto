using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using APICatalogo.Repository;
using AutoMapper;
using APICatalogo.DTOs;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly ILogger _logger;
        private readonly IUnitofWork _context;
        private readonly IMapper _mapper;
        

        public CategoriasController(IUnitofWork context, IMapper mapper, ILogger<CategoriasController> logger)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        //GET
        // GET: api/Categorias
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<CategoriaDTO>> GetCategoriasProduto()
        {
            var categorias = _context.CategoriaRepository.GetCategoriasProdutos().ToList();
            var categoriaDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDto;
        }


        // GET: api/Categorias
        [HttpGet]
        public  ActionResult<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categorias =  _context.CategoriaRepository.Get().ToList();
            var categoriaDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriaDto;
        }

        //GET: SAUDACAO
        [HttpGet("saudacao/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuservico, string nome)
        {
            return meuservico.Saudacao(nome);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public ActionResult<CategoriaDTO> GetCategoria(int id)
        {
            var categoria =  _context.CategoriaRepository.GetbyId(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDto;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutCategoria(int id, CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.CategoriaId)
            {
                return BadRequest();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.CategoriaRepository.Update(categoria);
            _context.Commit();

            return NoContent();
        }

        // POST: api/Categorias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult Post([FromBody]CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _context.CategoriaRepository.Add(categoria);
            _context.Commit();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoriaDTO);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public ActionResult<CategoriaDTO> DeleteCategoria(int id)
        {
            var categoria = _context.CategoriaRepository.GetbyId(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.CategoriaRepository.Delete(categoria);
            _context.Commit();

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return categoriaDto;
        }
    }
}
