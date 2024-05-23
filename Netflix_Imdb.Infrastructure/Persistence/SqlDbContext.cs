using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Netflix_Imdb.Application.Entity;

namespace Netflix_Imdb.Infrastructure.Persistence;

public partial class SqlDbContext : DbContext
{
    public SqlDbContext()
    {
    }

    public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A16F11023");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C291F002D");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E44500D7F1").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
