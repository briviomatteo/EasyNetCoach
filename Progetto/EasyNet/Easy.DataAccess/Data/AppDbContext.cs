using System;
using System.Collections.Generic;
using EasyNet.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyNet.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commento> Commentos { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
