using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class VendaDAO
    {
        public List<Venda> vendaLista = new List<Venda>();

        public void criarVenda(Venda venda)
        {
            vendaLista.Add(venda);
        }

        public void deletarVenda(int cod)
        {
            if(vendaLista.Remove(this.getVendaId(cod)))
            {
                Console.WriteLine("Item removido com sucesso!!!");
            }
            else
            {
                Console.WriteLine("Item não encontrado!!!");
            }
        }

        

        public Venda getVendaId(int id)
        {
            
            Venda venda = vendaLista.Find(x => x.IdVenda == id);
            if(venda != null)
                return venda;
            return null;
        }
        
        

        public void getTodos()
        {
            foreach(Venda c in vendaLista)
            {
                c.exibirVenda();
            }
        }
      
    }
}
