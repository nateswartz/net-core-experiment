namespace NETCoreExperimentalWebApp.Models
{
    public class BookModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookType Type { get; set; }
        public string Image { get; set; }
        public string userId { get; set; }
    }

    public enum BookType
    {
        Board, Electronic, Standard
    }
}
