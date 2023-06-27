using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        bool cpfValido = false;

        while (!cpfValido)
        {
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            
            if (!Regex.IsMatch(cpf, @"^[0-9]+$"))
            {
                Console.WriteLine("====================================================");
                Console.WriteLine("::CPF inválido. O CPF deve conter apenas números. ::");
                Console.WriteLine("====================================================");
                Console.WriteLine("\n");
                continue;
            }

            if (ValidarCPF(cpf))
            {
                Console.WriteLine("================");
                Console.WriteLine("::CPF válido! ::");
                Console.WriteLine("================");
                Console.WriteLine("\n");
                cpfValido = true;
            }
            else
            {
                Console.WriteLine("===================================");
                Console.WriteLine("::CPF inválido! Tente novamente. ::");
                Console.WriteLine("===================================");
                Console.WriteLine("\n");
            }
        }
    }

    static bool ValidarCPF(string cpf)
    {
        if (cpf.Length != 11)
        {
            return false;
        }

        if (TodosDigitosIguais(cpf))
        {
            return false;
        }

        if (!VerificarDigitoVerificador(cpf, 9, 10))
        {
            return false;
        }

        if (!VerificarDigitoVerificador(cpf, 10, 11))
        {
            return false;
        }

        return true;
    }

    static bool TodosDigitosIguais(string cpf)
    {
        for (int i = 1; i < 11; i++)
        {
            if (cpf[i] != cpf[0])
            {
                return false;
            }
        }

        return true;
    }

    static bool VerificarDigitoVerificador(string cpf, int multiplicadorInicial, int multiplicadorFinal)
    {
        int soma = 0;

        for (int i = 0; i < multiplicadorInicial; i++)
        {
            soma += (cpf[i] - '0') * (multiplicadorInicial + 1 - i);
        }

        int digitoVerificador = 11 - (soma % 11);

        if (digitoVerificador >= 10)
        {
            digitoVerificador = 0;
        }

        return cpf[multiplicadorInicial] - '0' == digitoVerificador;
    }
}