using System;

namespace ExPoo02 {
    class Endereco {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
    
        public Endereco(string rua, int numero, string bairro) {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
        }
        public override string ToString() {
            return ($"Rua: {Rua}\nNumero: {Numero}\nBairro: {Bairro}");
        }
    }
}