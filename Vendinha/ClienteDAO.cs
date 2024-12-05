using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class ClienteDAO
    {
        private List<Cliente> clienteLista = new List<Cliente>();

        public void criarCliente(Cliente cliente)
        {

            try
            {
                clienteLista.Add(cliente);
                Console.WriteLine("Cliente Cadastrado!!!");  
            } catch
            {
                Console.WriteLine("Erro ao cadastrar");
            }
        }

        public void deletarCliente(int cod)
        {
            if(clienteLista.Remove(this.getCliente(cod)))
                Console.WriteLine("Cliente removido com sucesso!!!\n");
        }
         
        public void attCliente(int cod, String nome, int idade, String cpf)
        {
            Cliente cliente = getCliente(cod);

            if(cliente != null)
            {
                cliente.Nome = nome;
                cliente.Idade = idade;
                cliente.Cpf = cpf;

                Console.WriteLine("Item atualizado: ");
                cliente.exibirCliente();
            }
            else
            {
                Console.WriteLine("Codigo não encontrado na lista de itens!!!");
            }
        }

        public Cliente getCliente(int cod)
        {
            
            Cliente cliente = clienteLista.Find(x => x.Codigo == cod);
            if(cliente != null)
                return cliente;
            Console.WriteLine("Cliente não encotrado!!!");
            return null;
        }

        public Cliente getCliente(String cpf)
        {

            Cliente cliente = clienteLista.Find(x => x.Cpf == cpf);
            if (cliente != null)
            {
                cliente.exibirCliente();
                return cliente;
            }
            return null;
        }

        public void getTodos()
        {
            foreach(Cliente c in clienteLista)
            {
                c.exibirCliente();
            }
        }


    }
}
