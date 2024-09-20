namespace BackgroundWorker.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string ? Title { get; set; }
        public int Year { get; set; }
        public string? RunTime { get; set; }
        public string? Genre { get; set; }
        public string ?Director { get; set; }
        public string ?Writer { get; set; }
        public string ?Actors { get; set; }
        public string ?Plot { get; set; }//description
    }
}
