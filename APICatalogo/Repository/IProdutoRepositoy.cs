using APICatalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Repository
{
    public interface IProdutoRepositoy : IRepository<Produto>
    {
        IEnumerable<Produto> GetProdutosPorPreco();
    }
}
