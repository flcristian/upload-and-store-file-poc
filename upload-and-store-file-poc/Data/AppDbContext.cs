using Microsoft.EntityFrameworkCore;
using upload_and_store_file_poc.Templates.Models;

namespace upload_and_store_file_poc.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Template> Templates { get; set; }

}