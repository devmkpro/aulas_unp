namespace Aula03
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Exercício 1");
            Console.WriteLine("2 - Exercício 2");
        }

        static void clear()
        {
            Console.Clear();
        }

        static void Main(string[] args)
        {
            menu();
            int escolha = lerInt();
            while (escolha != 0)
            {
                switch (escolha)
                {
                    case 1:
                        exercicio1();
                        break;
                    case 2:
                        exercicio2();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
                menu();
                escolha = lerInt();
            }

        }

        static void exercicio2()
        {
            Console.WriteLine("Digite o primeiro número: ");
            int num1 = lerInt();
            Console.WriteLine("Digite o segundo número: ");
            int num2 = lerInt();
            Console.WriteLine($"A soma de {num1} e {num2} é: " + (num1 + num2));
            Console.WriteLine("Digite qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static void exercicio1()
        {
            Console.WriteLine("Digite o seu nome: ");
            string nome = leString();

            Console.WriteLine($"Digite sua idade, {nome}: ");
            int idade = lerInt();

            Console.WriteLine($"Digite o número do mês do seu nascimento, {nome}: ");
            int mesNascimento = lerInt();

            int atual = DateTime.Now.Year;
            int mes = DateTime.Now.Month;

            int anoNascimento = atual - idade;
            if (mes < mesNascimento)
            {
                anoNascimento--;
            }

            Console.WriteLine($"Você nasceu em {anoNascimento}.");
            Console.WriteLine("Digite qualquer tecla para continuar.");
            Console.ReadKey();
            clear();
        }

        static void exercicio3()
        {

        }


        static string leString()
        {
            string input;
            do
            {
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        static int lerInt()
        {
            int input;
            bool success;
            do
            {
                success = int.TryParse(Console.ReadLine(), out input);
            } while (!success || input < 0);

            return input;
        }


    }
}