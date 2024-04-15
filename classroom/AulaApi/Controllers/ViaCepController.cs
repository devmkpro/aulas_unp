using System.Text.Json;
using Models;

namespace Controllers
{
    class ViaCepController
    {
        private readonly string _baseUrl;

        public ViaCepController(string baseUrl)
        {
            _baseUrl = baseUrl;
        }



        static async Task Main(string[] args)
        {
            var program = new ViaCepController("https://viacep.com.br/ws/");
            MostrarMenu();

            int escolha;
            while ((escolha = LerEscolha()) != 0)
            {
                switch (escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o CEP:");
                        var cep = Console.ReadLine();
                        var cepModel = await program.BuscarCep(cep);
                        cepModel.MostrarDados();
                        break;
                    case 2:
                        Console.WriteLine("Digite o CEP:");
                        var cepGerar = Console.ReadLine();
                        var cepModelGerar = await program.BuscarCep(cepGerar);
                        var local = new List<CepModel> { cepModelGerar };
                        var bytes = GerarExcel.GerarExcelLocal(local);
                        File.WriteAllBytes("local.xlsx", bytes);
                        Console.WriteLine("Planilha gerada com sucesso!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Digite novamente:");
                        break;
                }
                MostrarMenu();
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Apenas visualizar");
            Console.WriteLine("2 - Gerar planilha");
            Console.WriteLine("0 - Sair");
        }


        static int LerEscolha()
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("Opção inválida. Digite novamente:");
            }
            return escolha;
        }


        public async Task<CepModel> BuscarCep(string cep)
        {
            var url = $"{_baseUrl}{cep}/json";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var cepModel = JsonSerializer.Deserialize<CepModel>(json);
            return cepModel;
        }



    }
}

