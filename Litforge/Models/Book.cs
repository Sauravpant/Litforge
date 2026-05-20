namespace Litforge.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Author> BookAuthors { get; set; }
        public ICollection<Category> BookCategories { get; set; }


    }
}
