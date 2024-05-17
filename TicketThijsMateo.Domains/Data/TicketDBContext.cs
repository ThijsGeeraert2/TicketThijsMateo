using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.Domains.Data;

public partial class TicketDBContext : DbContext
{
    public TicketDBContext()
    {
    }

    public TicketDBContext(DbContextOptions<TicketDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonnementen> Abonnementens { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Soortplaatsen> Soortplaatsens { get; set; }

    public virtual DbSet<Stadium> Stadia { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Wedstrijden> Wedstrijdens { get; set; }

    public virtual DbSet<Zitplaatsen> Zitplaatsens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ticketsthijsmateo.database.windows.net; Database=TicketDB24; User Id=beheerder; Password=Hallo1234; MultipleActiveResultSets=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonnementen>(entity =>
        {
            entity.ToTable("Abonnementen");

            entity.HasIndex(e => e.ZitplaatsId, "IX_Abonnementen_ZitplaatsId")
                .IsUnique()
                .HasFilter("([ZitplaatsId] IS NOT NULL)");

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Zitplaats).WithOne(p => p.Abonnementen).HasForeignKey<Abonnementen>(d => d.ZitplaatsId);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasIndex(e => e.StadiumId, "IX_Clubs_StadiumId");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Clubs)
                .HasForeignKey(d => d.StadiumId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Soortplaatsen>(entity =>
        {
            entity.ToTable("Soortplaatsen");

            entity.HasIndex(e => e.StadiumId, "IX_Soortplaatsen_StadiumId");

            entity.Property(e => e.Tarief).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Soortplaatsens)
                .HasForeignKey(d => d.StadiumId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasIndex(e => e.WedstrijdId, "IX_Tickets_WedstrijdId");

            entity.HasIndex(e => e.ZitplaatsId, "IX_Tickets_ZitplaatsId");

            entity.Property(e => e.Betaald).HasColumnName("betaald");
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Wedstrijd).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.WedstrijdId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Zitplaats).WithMany(p => p.Tickets).HasForeignKey(d => d.ZitplaatsId);
        });

        modelBuilder.Entity<Wedstrijden>(entity =>
        {
            entity.ToTable("Wedstrijden");

            entity.HasIndex(e => e.StadiumId, "IX_Wedstrijden_StadiumId");

            entity.HasIndex(e => e.ThuisPloegId, "IX_Wedstrijden_ThuisPloegId");

            entity.HasIndex(e => e.TicketId, "IX_Wedstrijden_TicketId");

            entity.HasIndex(e => e.UitPloegId, "IX_Wedstrijden_UitPloegId");

            entity.HasOne(d => d.Stadium).WithMany(p => p.Wedstrijdens)
                .HasForeignKey(d => d.StadiumId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ThuisPloeg).WithMany(p => p.WedstrijdenThuisPloegs)
                .HasForeignKey(d => d.ThuisPloegId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Wedstrijdens).HasForeignKey(d => d.TicketId);

            entity.HasOne(d => d.UitPloeg).WithMany(p => p.WedstrijdenUitPloegs)
                .HasForeignKey(d => d.UitPloegId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Zitplaatsen>(entity =>
        {
            entity.ToTable("Zitplaatsen");

            entity.HasIndex(e => e.SoortplaatsId, "IX_Zitplaatsen_SoortplaatsId");

            entity.HasOne(d => d.Soortplaats).WithMany(p => p.Zitplaatsens).HasForeignKey(d => d.SoortplaatsId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
