using Microsoft.EntityFrameworkCore;

namespace News.Models
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
        }

        public DbSet<NewsItem> NewsItems { get; set; }
        
    }
}
