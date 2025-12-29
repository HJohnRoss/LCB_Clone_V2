using Microsoft.EntityFrameworkCore;
using LCB_Clone.Api.Infrastructure.Persistence.Entities;

namespace LCB_Clone.Api.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<Legislator> Legislators => Set<Legislator>();
	public DbSet<LegislatorStrings> LegislatorStrings => Set<LegislatorStrings>();
	public DbSet<Social> Socials => Set<Social>();
}
