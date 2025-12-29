using Microsoft.EntityFrameworkCore;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;

namespace LCB_Clone.Api.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Legislator> Legislators => Set<Legislator>();
    public DbSet<Social> Socials => Set<Social>();
}
