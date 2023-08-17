using ApiDotNet.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Data;

public class AppDbContext : DbContext
{
  public DbSet<User> Users {get; set;} = null!;
  // public DbSet<User> Wallet {get; set;}

  public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
}
