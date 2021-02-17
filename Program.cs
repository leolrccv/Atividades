using System;

namespace ExPoo02 {
    class Program {
        static void Main(string[] args) {
            int op, numero = 0, agencia = 0, cont = 0;
            string nome, cpf, rua, bairro, numeroConta = null;

            //unica conta destino
            Conta conta2 = new Conta(1010, "12345-6");
            do {
                Console.Write("Digite seu nome: ");
                nome = Console.ReadLine();
            } while (nome == "");

            do {
                Console.Write("Digite seu CPF: ");
                cpf = Console.ReadLine();
            } while (cpf == "");

            Pessoa pessoa = new Pessoa(nome, cpf);

            do {
                Console.Write("Digite sua rua: ");
                rua = Console.ReadLine();
            } while (rua == "");


            while (true) {
                try {
                    Console.Write("Digite seu numero da casa: ");
                    numero = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVOCÊ DEVE INFORMAR UM NÚMERO INTEIRO!!\n");
                    Console.ResetColor();
                }
            }
            do {
                Console.Write("Digite seu bairro: ");
                bairro = Console.ReadLine();
            } while (bairro == "");

            Endereco endereco = new Endereco(rua, numero, bairro);
            pessoa.Endereco = endereco;

            Console.Clear();

            do {
                Console.WriteLine("\n[1] - Informar os dados para abertura de conta");
                Console.WriteLine("[2] - Fazer depósito");
                Console.WriteLine("[3] - Realizar saque");
                Console.WriteLine("[4] - Transferir dinheiro");
                Console.WriteLine("[5] - Mostrar saldo");
                Console.WriteLine("[6] - Sair");

                while (true) {
                    try {
                        Console.Write("Informe a opção desejada: ");
                        op = int.Parse(Console.ReadLine());
                        if (op > 0 && op <= 6) break;

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nVOCÊ DEVE INFORMAR UM NÚMERO DE 1 A 6!!\n");
                        Console.ResetColor();
                    }
                    catch (Exception) {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nVOCÊ DEVE INFORMAR UM NÚMERO DE 1 A 6!!\n");
                        Console.ResetColor();
                    }
                }
                Console.Clear();

                switch (op) {
                    case 1:
                        if (cont == 0) {
                            AbrirConta(ref agencia, ref numeroConta);
                            Conta conta = new Conta(agencia, numeroConta);
                            pessoa.Conta = conta;
                            cont++;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nVOCÊ JÁ FEZ ABERTURA DE CONTA!!\n");
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        if (cont > 0) {
                            double dinheiro = 0;
                            DepositarDinheiro(ref dinheiro);
                            pessoa.Conta.Deposito(dinheiro);
                            cont++;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nVOCÊ DEVE ABRIR SUA CONTA PRIMEIRO\n");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        if (cont > 1) {
                            double dinheiro = 0;
                            SacarDinheiro(ref dinheiro);
                            pessoa.Conta.Saque(dinheiro);
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nVOCÊ DEVE DEVE DEPOSITAR DINHEIRO PRIMEIRO\n");
                            Console.ResetColor();
                        }
                        break;

                    case 4:
                        //numero da conta destino : 12345-6
                        //agencia da conta destino: 1010
                        if (cont > 1) {
                            double dinheiro = 0;
                            TransferirDinheiro(ref dinheiro);
                            if (dinheiro != 0) {
                                pessoa.Conta.Saque(dinheiro);
                                conta2.Deposito(dinheiro);
                            }
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nVOCÊ DEVE DEPOSITAR DINHEIRO PRIMEIRO\n");
                            Console.ResetColor();
                        }
                        break;

                    case 5:
                        if (cont > 0) {
                            Console.WriteLine($"\nSaldo da conta de {pessoa.Nome}: {pessoa.Conta.Saldo}");
                            Console.WriteLine($"\nSaldo da conta destino: {conta2.Saldo}");
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nVOCÊ DEVE ABRIR SUA CONTA PRIMEIRO\n");
                            Console.ResetColor();
                        }
                        break;
                }
            } while (op != 6);

            Console.WriteLine("Pressione qualquer tecla para sair!!");
            Console.ReadKey();
        }
        static void AbrirConta(ref int agencia, ref string numero) {
            Console.WriteLine();
            while (true) {
                try {
                    Console.Write("Informe a agencia: ");
                    agencia = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVOCÊ DEVE INFORMAR SOMENTE NÚMEROS!!\n");
                    Console.ResetColor();
                }
            }
            do {
                Console.Write("Informe a conta com dígito: ");
                numero = Console.ReadLine();
            } while (numero == "");

        }
        static void DepositarDinheiro(ref double dinheiro) {
            while (true) {
                try {
                    Console.Write("\nInforme a quantia que deseja depositar: ");
                    dinheiro = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVOCÊ DEVE INFORMAR SOMENTE NÚMEROS!!\n");
                    Console.ResetColor();
                }
            }

        }
        static void SacarDinheiro(ref double dinheiro) {
            while (true) {
                try {
                    Console.Write("\nInforme a quantia que deseja sacar: ");
                    dinheiro = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVOCÊ DEVE INFORMAR SOMENTE NÚMEROS!!\n");
                    Console.ResetColor();
                }
            }

        }
        static void TransferirDinheiro(ref double dinheiro) {
            int agencia = 0;
            string conta = null;
            while (true) {
                try {
                    Console.Write("\nDigite a agencia da conta destino: ");
                    agencia = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nVOCÊ DEVE INFORMAR SOMENTE NÚMEROS!!\n");
                    Console.ResetColor();
                }
            }
            Console.Write("Digite o número da conta, com dígito, da conta destino: ");
            conta = Console.ReadLine();

            if (agencia == 1010 && conta == "12345-6") {
                while (true) {
                    try {
                        Console.Write("Digite o valor que deseja transferir: ");
                        dinheiro = double.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception) {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nVOCÊ DEVE INFORMAR SOMENTE NÚMEROS!!\n");
                        Console.ResetColor();
                    }
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nCONTA INEXISTENTE!!\n");
                Console.ResetColor();
            }
        }
    }
}