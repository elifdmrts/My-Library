using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplicationYeni.Models;
public class AppDbContext: DbContext

    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Books> Books { get; set; }
    public DbSet<Writer> Writers { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

   
/*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Books>()
            .HasOne(b => b.Writer)
            .WithMany()
            .HasForeignKey(b => b.WriterId);

        modelBuilder.Entity<Books>()
            .HasOne(b => b.Publisher)
            .WithMany()
            .HasForeignKey(b => b.PublisherId);
    }*/
}










