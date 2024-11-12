using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewAPI.Models;

public partial class UsbmContext : DbContext
{
    public UsbmContext()
    {
    }

    public UsbmContext(DbContextOptions<UsbmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AU94EJS;Initial Catalog=Usbm;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId).HasName("PK__Student__FE2B448EC69263E5");

            entity.ToTable("Student");

            entity.Property(e => e.StdId).HasColumnName("Std_Id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StdName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Std_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
