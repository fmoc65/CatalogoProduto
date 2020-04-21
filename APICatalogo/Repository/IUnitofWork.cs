namespace APICatalogo.Repository
{
    public interface IUnitofWork
    {
        IProdutoRepositoy ProdutoRepositoy { get; }
        ICategoriaRepository CategoriaRepository { get; }
        void Commit();
    }
}
