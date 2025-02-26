namespace Movie_app.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        
        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }

        public Movie() { }



    }
}
