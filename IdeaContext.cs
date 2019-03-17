using Microsoft.EntityFrameworkCore;

namespace IdeasAPI.Models
{
    public class IdeaContext : DbContext
    {
        public IdeaContext(DbContextOptions options)
            : base(options)
            {

            }
        
        public DbSet<Idea> Ideas {get;set;}

        public DbSet<Tree> Trees {get;set;}
    }
}