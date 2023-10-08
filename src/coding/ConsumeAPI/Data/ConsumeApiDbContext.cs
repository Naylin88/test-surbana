using ConsumeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumeAPI.Data;

public class ConsumeApiDbContext : DbContext
{
    public ConsumeApiDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ImportantData> ImportantDatas { get; set; }
}
