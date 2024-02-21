using System.Net.Http.Json;

namespace JsonPlaceholderClient
{
  class Program
  {
    private readonly string _baseUrl;

    public Program(string baseUrl)
    {
      _baseUrl = baseUrl;
    }

    static void MostrarMenu()
    {
      Console.WriteLine("-----------------------------");
      Console.WriteLine("O que você deseja fazer?");
      Console.WriteLine("1 - Criar uma nova tarefa");
      Console.WriteLine("2 - Listar todas as tarefas");
      Console.WriteLine("0 - Sair");
    }

    static async Task Main(string[] args)
    {
      var program = new Program("https://jsonplaceholder.typicode.com");
      MostrarMenu();

      int escolha;
      while ((escolha = LerEscolha()) != 0)
      {
        switch (escolha)
        {
          case 1:
            await CriarTarefaAsync(program);
            break;
          case 2:
            await program.GetTasksAsync();
            break;
          default:
            MostrarMenu();
            Console.WriteLine("Opção inválida");
            break;
        }
      }
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

    static async Task CriarTarefaAsync(Program program)
    {
      string title = LerString("Digite o título da tarefa:");
      bool completed = LerBooleano("A tarefa está completa? (true/false):");
      int userId = LerInteiro("Digite o ID do usuário associado à tarefa:");

      await program.CreateTaskAsync(title, completed, userId);
      MostrarMenu();
    }

    static string LerString(string prompt)
    {
      string input;
      do
      {
        Console.WriteLine(prompt);
        input = Console.ReadLine();
      } while (string.IsNullOrEmpty(input));
      return input;
    }

    static bool LerBooleano(string prompt)
    {
      bool valor;
      Console.WriteLine(prompt);
      while (!bool.TryParse(Console.ReadLine(), out valor))
      {
        Console.WriteLine("Entrada inválida. Digite 'true' ou 'false':");
      }
      return valor;
    }

    static int LerInteiro(string prompt)
    {
      int valor;
      Console.WriteLine(prompt);
      while (!int.TryParse(Console.ReadLine(), out valor))
      {
        Console.WriteLine("Entrada inválida. Digite um número inteiro:");
      }
      return valor;
    }

    private async Task CreateTaskAsync(string title, bool completed, int userId)
    {
      using var httpClient = new HttpClient();

      var newTask = new Tasks(0, title, completed, userId);

      try
      {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync($"{_baseUrl}/todos", newTask);
        response.EnsureSuccessStatusCode();

        Tasks? createdTask = await response.Content.ReadFromJsonAsync<Tasks>();

        if (createdTask != null)
        {
          Console.WriteLine("-----------------------------");
          Console.WriteLine("Tarefa criada com sucesso:");
          Console.WriteLine($"Id: {createdTask.Id}");
          Console.WriteLine($"Title: {createdTask.Title}");
          Console.WriteLine($"Completed: {createdTask.Completed}");
          Console.WriteLine($"UserId: {createdTask.UserId}");
        }
        else
        {
          Console.WriteLine("Nenhuma tarefa foi criada.");
        }
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"Erro na requisição: {e.Message}");
      }
    }

    public async Task GetTasksAsync()
    {
      using var httpClient = new HttpClient();

      try
      {
        HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/todos");
        response.EnsureSuccessStatusCode();

        List<Tasks>? tasks = await response.Content.ReadFromJsonAsync<List<Tasks>>();

        if (tasks != null && tasks.Count > 0)
        {
          foreach (var todo in tasks)
          {
            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Title: {todo.Title}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"UserId: {todo.UserId}");
            Console.WriteLine();
          }
        }
        else
        {
          Console.WriteLine("Nenhuma tarefa encontrada.");
        }
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine($"Erro na requisição: {e.Message}");
      }

      MostrarMenu();
    }
  }

  public class Tasks
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public int UserId { get; set; }

    public Tasks(int id, string title, bool completed, int userId)
    {
      Id = id;
      Title = title;
      Completed = completed;
      UserId = userId;
    }
  }
}
