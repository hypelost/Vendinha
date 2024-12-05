using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class Venda 
    {
        private int idVenda;
        private static int contID = 0;
        private int codCliente;
        private ProdutosDAO dataProdutos;
        private List<Produtos> listaProdutos = new List<Produtos>();
        private List<int> qtdProdutos = new List<int>();
        private double total;
        private String nomeCliente;

        public int IdVenda { get => idVenda; set => idVenda = value; }
        public int CodCliente { get => codCliente; set => codCliente = value; }
        public List<int> QtdProdutos { get => qtdProdutos; set => qtdProdutos = value; }
        public List<Produtos> ListaProdutos { get => listaProdutos; set => listaProdutos = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public double Total { get => total; set => total = value; }

        public Venda(int codCliente, ProdutosDAO dataProdutos, String nomeCliente)
        {
            this.idVenda = this.gerarID();
            this.codCliente = codCliente;
            this.dataProdutos = dataProdutos;
            this.total = 0;
            this.nomeCliente = nomeCliente;
        }

        private int gerarID()
        {
            contID++;
            return contID;
        }
        
        public void incluirProduto(int codProduto)
        {
           
            Produtos produto = dataProdutos.getProdutoCodigo(codProduto);
            if (produto != null)
            {
                Console.WriteLine("Produto Adicionado!\n");
                if (listaProdutos.Contains(produto))
                {
                    qtdProdutos[listaProdutos.IndexOf(produto)]++;
                }
                else
                {
                    listaProdutos.Add(dataProdutos.getProdutoCodigo(codProduto));
                    qtdProdutos.Add(1);
                }

                this.total = calcTotal();
            }
        }

        public double calcTotal()
        {
            double soma = 0;
            foreach (Produtos x in listaProdutos)
            {
                soma += x.Preco * qtdProdutos[listaProdutos.IndexOf(x)];
            }
            return soma;
        }

        public void exibirVenda()
        {
            Console.WriteLine($"Codigo da venda: {idVenda}");
            Console.WriteLine($"Nome do Cliente: {nomeCliente}\n");

            foreach (Produtos x in listaProdutos)
            {
                Console.WriteLine($"Produto: {x.Modelo}");
                Console.WriteLine($"Preco: {x.Preco}");
                Console.WriteLine($"Quantidade: {qtdProdutos[listaProdutos.IndexOf(x)]}\n");
            }
            Console.WriteLine($"Total: {total}\n\n========================\n");
        }
    }

    
}
