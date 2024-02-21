namespace Entities
{
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