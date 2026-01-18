using Microsoft.EntityFrameworkCore;
using SocialAPI.Models;

namespace SocialAPI;

public class NoteDbContext(DbContextOptions<NoteDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
    // public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=c_sharp_notes;User ID=c_sharp_notes;Password=cSharp;",
            options => options.UseAdminDatabase("c_sharp_notes"));
        base.OnConfiguring(optionsBuilder);
    }
        
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().ToTable("notes");
        
        modelBuilder.Entity<Note>()
            .Property(n => n.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Note>()
            .Property(n => n.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
    }
}