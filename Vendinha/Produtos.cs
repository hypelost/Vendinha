using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Vendinha
{
    internal class Produtos
    {
        private int codigo;
        private string marca;
        private string modelo;
        private string descricao; 
        private double preco;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public double Preco { get => preco; set => preco = value; }

        public Produtos(int codigo, string marca, string modelo, string descricao, double preco)
        {
            this.Codigo = codigo;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Descricao = descricao;
            this.Preco = preco;
        }

        public Produtos(string marca)
        {
            this.Marca = marca;
        }

        public void exibirProduto()
        {
            Console.WriteLine($"Codigo: {Codigo}\nMarca: {Marca}\nModelo: {Modelo}\nDescricao: {Descricao}\n Preco: {Preco}");
        }
    }
}
