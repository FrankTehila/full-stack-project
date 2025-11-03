using System;
using System.Collections.Generic;
using DAL.models;
using Microsoft.EntityFrameworkCore;



namespace DAL.models;

public partial class dbClass : DbContext
{
    public dbClass()
    {
    }

    public dbClass(DbContextOptions<dbClass> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<TeamLeader> TeamLeaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection String מוגדר כעת ב-Program.cs דרך Dependency Injection
        // אין צורך להגדיר כאן אלא אם זה בדיקות יחידה
        if (!optionsBuilder.IsConfigured)
        {
            // זה יופעל רק אם לא הוזרק DbContext דרך DI (לדוגמה, בטסטים)
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07227DB59F");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.LeaderId).HasColumnName("leaderId");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B0C2164B");

            entity.ToTable("Meeting");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Duration)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("duration");
            entity.Property(e => e.LeaderId).HasColumnName("leaderId");
            entity.Property(e => e.RoomId).HasColumnName("roomId");
            entity.Property(e => e.StartTime)
                .HasPrecision(0)
                .HasColumnName("startTime");

            entity.HasOne(d => d.Leader).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.LeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meeting__leaderI__68487DD7");

            entity.HasOne(d => d.Room).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Meeting__roomId__693CA210");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07F185C933");

            entity.ToTable("Room");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<TeamLeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamLead__3214EC0707B20BA5");

            entity.ToTable("TeamLeader");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.NumOfWorkers).HasColumnName("numOfWorkers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
