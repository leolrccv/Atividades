using System;

namespace ExPoo02 {
    class Conta {
        public int Agencia { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }

        public Conta(int agencia, string numero) {
            Agencia = agencia;
            NumeroConta = numero;
            Saldo = 0;
        }

        public void Deposito(double dinheiro) {
            if (dinheiro < 0) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nO VALOR NÃO PODE SER NEGATIVO!!\n");
                Console.ResetColor();
            }
            else Saldo += dinheiro;
        }

        public void Saque(double dinheiro) {
            if (dinheiro > Saldo) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nO VALOR NÃO PODE SER SUPERIOR AO SALDO!!\n");
                Console.ResetColor();
            }
            else {
                if (dinheiro < 0) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nO VALOR NÃO PODE SER NEGATIVO!!\n");
                    Console.ResetColor();
                }else Saldo -= dinheiro;
            }
        }

        public override string ToString() {
            return ($"Agencia: {Agencia}\nNúmero da Conta: {NumeroConta}\nSaldo: {Saldo}");
        }
    }
}