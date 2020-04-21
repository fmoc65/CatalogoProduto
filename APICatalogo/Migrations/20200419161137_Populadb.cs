using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias (Nome,ImagemUrl) values ('Bebidas', 'https://www.bebidasfamosas.com.br/blog/wp-content/uploads/2016/01/Quais-bebidas-s%C3%A3o-mais-consumidas-no-Brasil.png')");
            mb.Sql("Insert into Categorias (Nome,ImagemUrl) values ('Lanches', 'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTcMAvkFkEjfpi1ESTEgtLFlZs-CwH04Qq6XAJ2k5KdznufYS89&usqp=CAU')");
            mb.Sql("Insert into Categorias (Nome,ImagemUrl) values ('Sobremesas', 'https://receitatodahora.com.br/wp-content/uploads/2017/08/sobremesa-para-o-dia-dos-pais.jpg')");

            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) Values ('Coca-Cola','Regrigente de 2 litros', "+
                "6.78,'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcThIjEmPw1fYEe5T6w_k48Y1rJou2h_sxpo4g-qL45mbrSwvnZx&usqp=CAU',50,now(),"+
                "(select CategoriaId from Categorias where nome='Bebidas'))");
            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                "Values ('Hamburguer','Hamburguer artesanal, com pão, maionese, tomate, bacon, ovos e fritas',22.50,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb2gW0GMaWB5yffpzQltEAZ-WcKf34EXL3R2Bs9S1JeHiUb7cArw&s'," +
                "35,now(), (select CategoriaId from Categorias where nome='Lanches'))");
            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values ('Tiramissu','consiste em camadas de biscoitos de champagne, também chamados de biscoitos tipo inglês ou palitos a la reine  embebidas em café ',16,'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSTC5qHq80Jp7sQkVXpsc2e2uaZsKKUbni8EWu9kcDg7GAT1V9S&usqp=CAU'," +
                "15,now(), (select CategoriaId from Categorias where nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");

        }
    }
}
