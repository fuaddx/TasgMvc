namespace Pustok2.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
