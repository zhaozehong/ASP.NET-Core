using DotNetCoreApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreApp.Data
{
  public class DotNetCoreAppDbContext : DbContext
  {
    public DotNetCoreAppDbContext(DbContextOptions<DotNetCoreAppDbContext> options) : base(options) { }

    public DbSet<Restaurant> Restaurants { get; set; }
  }
}
