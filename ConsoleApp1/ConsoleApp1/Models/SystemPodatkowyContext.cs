using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

public partial class SystemPodatkowyContext : DbContext
{
    public virtual DbSet<Pit> Pity { get; set; }
    public virtual DbSet<Podatnik> Podatnicy { get; set; }
    public virtual DbSet<Pole> Pola { get; set; }
    public virtual DbSet<UrzadSkarbowy> UrzadySkarbowe { get; set; }
    public virtual DbSet<Zeznanie> Zeznania { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LUKASZ\\MSSQLSERVER02;Database=systemPodatkowy;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pit>(entity =>
        {
            entity.Property(e => e.PitId).HasColumnName("pitID");

            entity.Property(e => e.NrDokumentu)
                .HasMaxLength(50)
                .HasColumnName("nrDokumentu");

            entity.Property(e => e.PoleId).HasColumnName("poleID");
            entity.Property(e => e.RokPodatkowy)
                .HasColumnType("date")
                .HasColumnName("rokPodatkowy");

            entity.Property(e => e.Status)
                .HasMaxLength(40)
                .HasColumnName("status");

            entity.HasOne(d => d.Pole).WithMany(p => p.Pity)
                .HasForeignKey(d => d.PoleId);
        });

        modelBuilder.Entity<Podatnik>(entity =>
        {
            entity.Property(e => e.PodatnikId).HasColumnName("podatnikID");

            entity.Property(e => e.DataUrodzenia)
                .HasColumnType("date")
                .HasColumnName("dataUrodzenia");

            entity.Property(e => e.Gmina)
                .HasMaxLength(40)
                .HasColumnName("gmina");

            entity.Property(e => e.Imie)
                .HasMaxLength(40)
                .HasColumnName("imie");

            entity.Property(e => e.KodPocztowy)
                .HasMaxLength(6)
                .HasColumnName("kodPocztowy");

            entity.Property(e => e.Kraj)
                .HasMaxLength(40)
                .HasColumnName("kraj");

            entity.Property(e => e.Miejsowość)
                .HasMaxLength(40)
                .HasColumnName("miejsowość");

            entity.Property(e => e.Nazwisko)
                .HasMaxLength(40)
                .HasColumnName("nazwisko");

            entity.Property(e => e.Nip)
                .HasMaxLength(10)
                .HasColumnName("nip");

            entity.Property(e => e.NrDomu)
                .HasMaxLength(10)
                .HasColumnName("nrDomu");

            entity.Property(e => e.NrLokalu)
                .HasMaxLength(10)
                .HasColumnName("nrLokalu");

            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .HasColumnName("pesel");

            entity.Property(e => e.Powiat)
                .HasMaxLength(40)
                .HasColumnName("powiat");

            entity.Property(e => e.Ulica)
                .HasMaxLength(40)
                .HasColumnName("ulica");

            entity.Property(e => e.Województwo)
                .HasMaxLength(40)
                .HasColumnName("województwo");
        });

        modelBuilder.Entity<Pole>(entity =>
        {
            entity.Property(e => e.PoleId).HasColumnName("poleID");

            entity.Property(e => e.CzyBool).HasColumnName("czyBool");

            entity.Property(e => e.NazwaPola)
                .HasMaxLength(40)
                .HasColumnName("nazwaPola");

            entity.Property(e => e.OpisPola).HasColumnName("opisPola");
        });

        modelBuilder.Entity<UrzadSkarbowy>(entity =>
        {
            entity.Property(e => e.UrzadId).HasColumnName("urzadID");

            entity.Property(e => e.KodPocztowy)
                .HasMaxLength(6)
                .HasColumnName("kodPocztowy");

            entity.Property(e => e.Miejsowość)
                .HasMaxLength(40)
                .HasColumnName("miejsowość");

            entity.Property(e => e.NrDomu)
                .HasMaxLength(10)
                .HasColumnName("nrDomu");

            entity.Property(e => e.Powiat)
                .HasMaxLength(40)
                .HasColumnName("powiat");

            entity.Property(e => e.Ulica)
                .HasMaxLength(40)
                .HasColumnName("ulica");

            entity.Property(e => e.Województwo)
                .HasMaxLength(40)
                .HasColumnName("województwo");
        });

        modelBuilder.Entity<Zeznanie>(entity =>
        {
            entity.Property(e => e.ZeznaniaId).HasColumnName("zeznaniaID");

            entity.Property(e => e.DataZlozenia)
                .HasColumnType("date")
                .HasColumnName("dataZlozenia");

            entity.Property(e => e.PitId).HasColumnName("pitID");
            entity.HasOne(d => d.Pit).WithMany(p => p.Zeznania)
                  .HasForeignKey(d => d.PitId);

            entity.Property(e => e.PodatnikId).HasColumnName("podatnikID");
            entity.HasOne(d => d.Podatnik).WithMany(p => p.Zeznania)
                  .HasForeignKey(d => d.PodatnikId);

            entity.Property(e => e.UrzadId).HasColumnName("urzadID");
            entity.HasOne(d => d.Urzad).WithMany(p => p.Zeznania)
                  .HasForeignKey(d => d.UrzadId);
        });
    }
}
