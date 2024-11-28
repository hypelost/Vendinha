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
            clienteLista.Add(cliente);
        }

        public void deletarCliente(int cod)
        {
            if(clienteLista.Remove(this.getClienteCodigo(cod)))
            {
                Console.WriteLine("Item removido com sucesso!!!");
            }
            else
            {
                Console.WriteLine("Item não encontrado!!!");
            }
        }

        public void attCliente(int cod, String nome, int idade, String cpf)
        {
            Cliente cliente = getClienteCodigo(cod);

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

        public Cliente getClienteCodigo(int cod)
        {
            
            Cliente cliente = clienteLista.Find(x => x.Codigo == cod);
            if(cliente != null)
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
