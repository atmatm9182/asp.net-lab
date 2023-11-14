﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder
                .Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 1,
                        Name = "WSEI",
                        Description = "Uczelnia Wyższa",
                    },
                    new OrganizationEntity()
                    {
                        Id = 2,
                        Name = "PKP",
                        Description = "Przewoźnik kolejowy",
                    }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity()
                {
                    ContactId = 1,
                    Name = "Adam",
                    Email = "adam@wsei.edu.pl",
                    Phone = "28392834923",
                    Birth = new DateTime(1999, 7, 1),
                    Priority = 2,
                    OrganizationId = 1,
                },
                new ContactEntity()
                {
                    ContactId = 2,
                    Name = "Ewa",
                    Email = "ewa@wsei.edu.pl",
                    Phone = "1239595599",
                    Birth = new DateTime(2000, 1, 14),
                    Priority = 2,
                    OrganizationId = 2,
                }
            );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new
                    {
                        OrganizationEntityId = 1,
                        City = "Kraków",
                        Street = "Św. Filipa 17",
                        PostalCode = "31-150",
                    },
                    new
                    {
                        OrganizationEntityId = 2,
                        City = "Kraków",
                        Street = "Dworcowa 7",
                        PostalCode = "31-150",
                    }
                );
        }
    }
}
