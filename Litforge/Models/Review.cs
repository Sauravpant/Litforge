namespace Litforge.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Description { get; set; }

        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Reviewer { get; set; }
        public Book Book { get; set; }

    }
}
