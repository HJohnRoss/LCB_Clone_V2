using Microsoft.EntityFrameworkCore;
using LCB_Clone.Shared.Models;

namespace LCB_Clone.Api.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

	public DbSet<Legislator> Legislators => Set<Legislator>();
}
