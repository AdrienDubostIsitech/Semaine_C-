using Microsoft.EntityFrameworkCore; 

public class WebApiDbContext: DbContext 
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) 
    {
        
    }

    public DbSet<Hero>? Heroes { get; set; }
    public DbSet<Film>? Films { get; set; }
    public DbSet<Power> Powers { get; set; }
}