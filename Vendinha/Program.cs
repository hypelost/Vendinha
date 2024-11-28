using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            
            clienteDAO.criarCliente(new Cliente(123, "David", 20, "52068697831"));
            clienteDAO.criarCliente(new Cliente(456, "Igor", 20, "ocaraecorno"));

            

            clienteDAO.getTodos();
            clienteDAO.getClienteCodigo(123);
            clienteDAO.deletarCliente(123);
            clienteDAO.getTodos();
            clienteDAO.attCliente(456, "Joao", 38, "12312312380");



            ProdutosDAO produtosDAO = new ProdutosDAO();
            produtosDAO.criarProduto(new Produtos(1, "daco", "geladeira", "geladeira daco", 50.00));
            produtosDAO.criarProduto(new Produtos(2, "dafa", "renata", "renata fa", 510.00));

            produtosDAO.getTodos();
            produtosDAO.getProdutoCodigo(1);
            produtosDAO.deleteProdutoCodigo(2);
            produtosDAO.attProdutos(1, "dafada", "roberta", "renata", 56.00);

        }
    }
}