using System;
using BAAC.Memberships.Models;
using Microsoft.EntityFrameworkCore;

namespace BAAC.Memberships.Services.Data {
  public class AppDb : DbContext {

    public AppDb(DbContextOptions<AppDb> options) : base(options) {

    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Package> Packages { get; set; }

    public DbSet<Subscription> Subscriptions { get; set; }


  }
}
