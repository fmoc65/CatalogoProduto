using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepositoy
    {
        public ProdutoRepository(AppDbContext contexto) : base(contexto)
        {

        }
        public IEnumerable<Produto> GetProdutosPorPreco()
        {
            return Get().OrderBy(c => c.Preco).ToList();
        }
    }
}
