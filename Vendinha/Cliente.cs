using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendinha
{
    internal class Cliente
    {
        private int codigo ;
        private String nome;
        private int idade;
        private String cpf;

        public Cliente()
        {
            
        }

        public Cliente(int codigo, String nome, int idade, String cpf)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Idade { get => idade; set => idade = value; }
        public string Cpf { get => cpf; set => cpf = value; }

        public void exibirCliente(){
            Console.WriteLine($"Codigo: {Codigo}\nNome: {Nome}\nIdade: {Idade}\nCPF: {Cpf}\n");
        }

    }
}

