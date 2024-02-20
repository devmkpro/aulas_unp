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
 
    
    static async Task Main(string[] args)
    {
      var program = new Program("https://jsonplaceholder.typicode.com");
      
      await program.GetPostsAsync();

      Console.ReadKey();
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

  }

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
}