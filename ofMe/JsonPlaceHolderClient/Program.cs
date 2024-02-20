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
 

    static void Finalizar()
    {
      Console.WriteLine("Pressione qualquer tecla para finalizar...");
      Console.ReadKey();
    }

    
    static async Task Main(string[] args)
    {
      var program = new Program("https://jsonplaceholder.typicode.com");
      
      await program.GetTodosAsync();

      Finalizar();
    }


    public async Task GetPostsAsync()
    {
      using var httpClient = new HttpClient();

      try 
      {
        HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/posts");

        response.EnsureSuccessStatusCode(); // verificando se a resposta foi bem sucedida

        List<Post>? posts = await response.Content.ReadFromJsonAsync<List<Post>>();

        if (posts != null && posts.Count > 0)
        {
          foreach (var post in posts)
          {
            Console.WriteLine($"Id: {post.Id}");
            Console.WriteLine($"Title: {post.Title}");
            Console.WriteLine($"Body: {post.Body}");
            Console.WriteLine();
          }
        }
        else 
        {
          Console.WriteLine("No posts were found");
        }

      }
        catch (HttpRequestException e)
        {
          Console.WriteLine($"Request exception: {e.Message}");
        }
    }

    public async Task GetTodosAsync()
    {
      using var httpClient = new HttpClient();

      try 
      {
        HttpResponseMessage response = await httpClient.GetAsync($"{_baseUrl}/todos");

        response.EnsureSuccessStatusCode(); // verificando se a resposta foi bem sucedida

        List<Todo>? todos = await response.Content.ReadFromJsonAsync<List<Todo>>();

        if (todos != null && todos.Count > 0)
        {
          foreach (var todo in todos)
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
          Console.WriteLine("No todos were found");
        }

      }
        catch (HttpRequestException e)
        {
          Console.WriteLine($"Request exception: {e.Message}");
        }
    }

  }

  /**
    The Post and Todo classes are used to deserialize the JSON response into C# objects.
  */ 
  public class Post
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public Post(int id, string title, string body)
    {
      Id = id;
      Title = title;
      Body = body;
    }
  }

  public class Todo
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public int UserId { get; set; }


    public Todo(int id, string title, bool completed, int userId)
    {
      Id = id;
      Title = title;
      Completed = completed;
      UserId = userId;
    }
  
  }
}