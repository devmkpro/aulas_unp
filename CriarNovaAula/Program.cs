namespace CriarNovaAula
{
  class Program
  {
    private string _diretorio;

    public Program(string diretorio)
    {
      _diretorio = diretorio;
    }

    static void Main(string[] args)
    {
      Program programa = new Program("classroom");
      programa.CriarPastaEProjeto();
    }

    void CriarPastaEProjeto()
    {
      string nomeAula = ObterNomeAula();
      string path = Path.Combine(Directory.GetCurrentDirectory(), "..", _diretorio, nomeAula);

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
        Console.WriteLine($"Pasta '{nomeAula}' criada com sucesso!");
      }
      else
      {
        Console.WriteLine($"A pasta '{nomeAula}' já existe.");
      }

      // Navega para o diretório da aula
      Directory.SetCurrentDirectory(path);

      string nomeProjeto = ObterNomeProjeto();

      // Cria o projeto C#
      string comando = $"dotnet new console -n {nomeProjeto}";
      ExecutarComandoCMD(comando);

      Console.WriteLine($"Projeto '{nomeProjeto}' criado com sucesso em '{nomeAula}'.");
    }

    string ObterNomeAula()
    {
      Console.WriteLine("Digite o nome da aula: ");
      string? nomeAula = Console.ReadLine();

      while (string.IsNullOrEmpty(nomeAula))
      {
        Console.WriteLine("Nome da aula inválido.");
        Console.WriteLine("Digite o nome da aula: ");
        nomeAula = Console.ReadLine();
      }

      return nomeAula;
    }

    string ObterNomeProjeto()
    {
      Console.Write("Digite o nome do projeto C#: ");
      string? nomeProjeto = Console.ReadLine();

      while (string.IsNullOrEmpty(nomeProjeto))
      {
        Console.WriteLine("Nome do projeto inválido.");
        Console.Write("Digite o nome do projeto C#: ");
        nomeProjeto = Console.ReadLine();
      }

      return nomeProjeto;
    }

    void ExecutarComandoCMD(string comando)
    {
      try
      {
        System.Diagnostics.Process.Start("cmd.exe", $"/c {comando}").WaitForExit();
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro ao executar o comando: {ex.Message}");
      }
    }
  }
}
