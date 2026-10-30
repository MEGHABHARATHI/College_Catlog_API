using Microsoft.EntityFrameworkCore;
using CollegeCatalog.API.Models;

namespace CollegeCatalogAPI.Data;

public class CollegeDbContext : DbContext
{
    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
    {
    }

    public DbSet<College> Colleges { get; set; }
}