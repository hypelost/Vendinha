using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendinha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            clienteDAO.criarCliente(new Cliente(123, "David", 19, "52068697831"));
            clienteDAO.criarCliente(new Cliente(456, "Igor", 20, "17589856720"));

            ProdutosDAO produtosDAO = new ProdutosDAO();
            produtosDAO.criarProduto(new Produtos(1, "Consul", "Geladeira", "Geladeira Consul 250L", 1999.99));
            produtosDAO.criarProduto(new Produtos(2, "Samsung", "Televisão", "Smart TV 58' 4K OLED", 2399.99));

            VendaDAO vendaDAO = new VendaDAO();

            int op, produto=1, delete;

            do
            {
                op = 13;
                Console.WriteLine("Escolha uma opcao: ");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Buscar Cliente por Código");
                Console.WriteLine("3 - Listar Clientes");
                Console.WriteLine("4 - Deletar Cliente\n");
                Console.WriteLine("5 - Cadastrar Produto");
                Console.WriteLine("6 - Buscar Produto");
                Console.WriteLine("7 - Listar Produto");
                Console.WriteLine("8 - Deletar Produto\n");
                Console.WriteLine("9 - Nova Venda");
                Console.WriteLine("10 - Buscar Venda");
                Console.WriteLine("11 - Listar Vendas");
                Console.WriteLine("12 - Total de Vendas");
                Console.WriteLine("Aperte qualquer outra tecla para sair");
                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("ERRO!!! Tente Novamente");
                }

                Console.Clear();

                if (op < 0 || op > 13)
                {
                    Console.WriteLine("Opcao Invalida!!!");
                    op = 13;
                }
                else
                {
                    try
                    {
                        switch (op)
                        {
                            case 1:
                                Console.WriteLine("Codigo: ");
                                int codigo = int.Parse(Console.ReadLine());
                                if (clienteDAO.getCliente(codigo) != null)
                                {
                                    Console.WriteLine("Codigo já cadastrado!!!\n");
                                    break;
                                }
                                Console.WriteLine("Nome: ");
                                String nome = Console.ReadLine();
                                Console.WriteLine("Idade: ");
                                int idade = int.Parse(Console.ReadLine());
                                Console.WriteLine("CPF: ");
                                String cpf = Console.ReadLine();
                                if (clienteDAO.getCliente(cpf) != null)
                                {
                                    Console.WriteLine("CPF já cadastrado!!!\n");
                                    break;
                                }
                                clienteDAO.criarCliente(new Cliente(codigo, nome, idade, cpf));
                                break;

                            case 2:
                                Console.WriteLine("Digite o código:");
                                try
                                {
                                    clienteDAO.getCliente(int.Parse(Console.ReadLine())).exibirCliente();
                                }
                                catch
                                {
                                    Console.WriteLine("Tente Novamente!\n");
                                }

                                break;

                            case 3:
                                clienteDAO.getTodos();
                                break;

                            case 4:
                                Console.WriteLine("Informe o código do cliente que deseja deletar: ");
                                delete = 1;
                                int codCliente = int.Parse(Console.ReadLine());
                                foreach (Venda x in vendaDAO.vendaLista)
                                {
                                    if (x.CodCliente == codCliente)
                                    {
                                        delete = 0;
                                        Console.WriteLine("Cliente não pode ser deletado, pois já está realizou uma compra!\n");
                                        break;
                                    }
                                }
                                if (delete == 1)
                                    clienteDAO.deletarCliente(codCliente);
                                break;

                            case 5:
                                Console.WriteLine("Codigo: ");
                                int codProduto = int.Parse(Console.ReadLine());
                                if (produtosDAO.getProdutoCodigo(codProduto) != null)
                                {
                                    Console.WriteLine("Codigo já cadastrado!!!\n");
                                    break;
                                }
                                Console.WriteLine("Marca: ");
                                String marca = Console.ReadLine();
                                Console.WriteLine("Modelo: ");
                                String modelo = Console.ReadLine();
                                Console.WriteLine("Descrição: ");
                                String desc = Console.ReadLine();
                                Console.WriteLine("Preco: ");
                                double preco = double.Parse(Console.ReadLine());

                                produtosDAO.criarProduto(new Produtos(codProduto, marca, modelo, desc, preco));
                                break;

                            case 6:
                                Console.WriteLine("Digite o código:");
                                produtosDAO.getProdutoCodigo(int.Parse(Console.ReadLine())).exibirProduto();
                                break;

                            case 7:
                                produtosDAO.getTodos();
                                break;

                            case 8:
                                delete = 1;
                                Console.WriteLine("Informe o código do produto que deseja deletar:");
                                int codDeletar = int.Parse(Console.ReadLine());
                                foreach (Venda x in vendaDAO.vendaLista)
                                {
                                    foreach (Produtos p in x.ListaProdutos)
                                    {
                                        if (p.Codigo == codDeletar)
                                        {
                                            delete = 0;
                                            Console.WriteLine("Produto não pode ser deletado, pois já está em uma compra!\n");
                                            break;
                                        }
                                    }
                                }
                                if (delete == 1)
                                    produtosDAO.deleteProdutoCodigo(codDeletar);
                                break;

                            case 9:
                                Console.WriteLine("Informe o codigo do cliente que relizará a compra:");
                                codigo = int.Parse(Console.ReadLine());

                                try
                                {
                                    Venda venda = new Venda(codigo, produtosDAO, clienteDAO.getCliente(codigo).Nome);

                                    vendaDAO.criarVenda(venda);

                                    while (produto != 0)
                                    {
                                        Console.WriteLine("Selecione os produtos para adicionar à compra: ");
                                        produtosDAO.getTodos();
                                        produto = int.Parse(Console.ReadLine());
                                        Console.Clear();

                                        if (produto != 0)
                                            vendaDAO.getVendaId(venda.IdVenda).incluirProduto(produto);

                                        vendaDAO.getVendaId(venda.IdVenda).exibirVenda();
                                    }
                                    produto = 1;
                                }
                                catch
                                {
                                    Console.WriteLine("Tente Novamente!\n");
                                }
                                break;

                            case 10:
                                try
                                {
                                    Console.WriteLine("Informe o código da venda: ");
                                    vendaDAO.getVendaId(int.Parse(Console.ReadLine())).exibirVenda();
                                }
                                catch
                                {
                                    Console.WriteLine("Não encontrado!!!");
                                }
                                break;

                            case 11:
                                vendaDAO.getTodos();
                                break;

                            case 12:
                                double totalVendas = 0;
                                Console.WriteLine($"Total de Vendas: {vendaDAO.vendaLista.Count()}");
                                foreach (Venda x in vendaDAO.vendaLista)
                                {
                                    totalVendas += x.Total;
                                }
                                Console.WriteLine($"Faturamento: {totalVendas}\n");
                                break;

                            default:
                                Console.WriteLine("Deseja realmente sair? S/N");
                                if (Console.ReadLine().ToUpper().Equals("N"))
                                    op = 1;

                                Console.Clear();
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ERRO! Tente novamente");
                    }
                }
                
            } while (op > 0 && op < 13);

        }
    }
}