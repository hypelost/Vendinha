using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class ProdutosDAO 
    {
        public List<Produtos> produtosL = new List<Produtos>() ;
        public void criarProduto(Produtos produtos)
        {
            produtosL.Add(produtos);

        }


        public void deleteAllProdutos(List<Produtos> produtos) { produtosL.Clear(); }
        public Produtos getProdutoCodigo(int cod)
        {
            Produtos produto = produtosL.Find(x => x.Codigo == cod);
            if (produto != null)
                return produto;
            Console.WriteLine("Produto não cadastrado");
            return null;
        }


        public void attProdutos(int cod, String marca, String modelo, String descricao, double preco)
        {
            Produtos produto = getProdutoCodigo(cod);

            if (produto != null)
            {
                produto.Marca = marca;
                produto.Modelo = modelo;
                produto.Descricao = descricao;
                produto.Preco = preco;

                Console.WriteLine("Item atualizado: ");
                produto.exibirProduto();
            }
            else
            {
                Console.WriteLine("Codigo não encontrado na lista de itens!!!");
            }
        }
        public Produtos deleteProdutoCodigo(int cod)
        {
            Produtos produtos = produtosL.Find(codigo => codigo.Codigo == cod);
            if (produtos != null)
            {
                produtosL.Remove(produtos);
                Console.WriteLine("Produto deletado com sucesso!!!\n");
                return produtos;
            }
            return null;
        }
        public void getTodos()
        {
            foreach (Produtos p in produtosL)
            {
                p.exibirProduto();
            }
        }
    }
}
