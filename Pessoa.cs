using System;

namespace ExPoo02 {
    class Pessoa {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public Conta Conta { get; set; }

        public void print() {
            Console.WriteLine("Nome: " + Nome);
            Console.WriteLine("Cpf: " + Cpf);
            Console.WriteLine(Endereco);
            Console.WriteLine(Conta);
        }
        public Pessoa(string nome, string cpf) {
            Nome = nome;
            Cpf = cpf;
        }
    }
}