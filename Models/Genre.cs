namespace Movie_app.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
