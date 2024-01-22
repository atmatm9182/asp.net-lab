using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public DbSet<OperatingSystemEntity> OperatingSystems { get; set; }
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "contacts.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRole = new IdentityRole()
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = Guid.NewGuid().ToString(),
            };
            adminRole.ConcurrencyStamp = adminRole.Id;

            var regularRole = new IdentityRole()
            {
                Name = "regular",
                NormalizedName = "REGULAR",
                Id = Guid.NewGuid().ToString(),
            };
            regularRole.ConcurrencyStamp = regularRole.Id;

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole, regularRole);

            PasswordHasher<IdentityUser> hasher = new();

            var adminUser = new IdentityUser()
            {
                UserName = "pudzian",
                Email = "pudzian@wsei.edu.pl",
                NormalizedEmail = "PUDZIAN@WSEI.EDU.PL",
                EmailConfirmed = true,
                Id = Guid.NewGuid().ToString(),
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "1AdAbAcAdAbA_!@");

            var regularUser = new IdentityUser()
            {
                UserName = "user",
                Email = "user@wsei.edu.pl",
                NormalizedEmail = "USER@WSEI.EDU.PL",
                EmailConfirmed = true,
                Id = Guid.NewGuid().ToString(),
            };
            regularUser.PasswordHash = hasher.HashPassword(regularUser, "abcd9876!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(adminUser, regularUser);
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId = adminUser.Id,
                    },

                    new IdentityUserRole<string>()
                    {
                        RoleId = regularRole.Id,
                        UserId = regularUser.Id,
                    }
                );

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
                        Country = "Poland",
                        City = "Kraków",
                        Street = "Św. Filipa 17",
                        PostalCode = "31-150",
                    },
                    new
                    {
                        OrganizationEntityId = 2,
                        Country = "Poland",
                        City = "Kraków",
                        Street = "Dworcowa 7",
                        PostalCode = "31-150",
                    }
                );

            var manufacturerDell = new ManufacturerEntity()
            {
                Id = 1,
                Name = "DELL",
                Description =
                    """
                    Dell Inc. is an American-based technology company. It develops, sells, repairs,
                    and supports computers and related products and services.
                    """,
                WebsiteUrl = "www.dell.com",
            };

            var manufacturerHp = new ManufacturerEntity()
            {
                Id = 2,
                Name = "HP",
                Description =
                    """
                    HP Inc. is an American multinational information technology company headquartered in Palo Alto, California, 
                    that develops personal computers, printers and related supplies, as well as 3D printing solutions.
                    """,
                WebsiteUrl = "www.hp.com",
            };

            var manufacturerAsus = new ManufacturerEntity()
            {
                Id = 3,
                Name = "ASUS",
                Description = """
                              ASUSTeK Computer Inc. is a Taiwanese multinational computer, phone hardware and electronics manufacturer
                              """,
                WebsiteUrl = "www.asus.com",
            };

            modelBuilder.Entity<ManufacturerEntity>()
                .HasData(manufacturerDell, manufacturerHp, manufacturerAsus);

            modelBuilder.Entity<ManufacturerEntity>()
                .OwnsOne(m => m.Address)
                .HasData(
                    new
                    {
                        ManufacturerEntityId = 1,
                        Country = "USA",
                        City = "Round Rock, Texas",
                        Street = "South Interstate",
                        PostalCode = "78664",
                    },
                    new
                    {
                        ManufacturerEntityId = 2,
                        Country = "USA",
                        City = "Palo Alto, California",
                        Street = "Honover",
                        PostalCode = "94020",
                    },
                    new
                    {
                        ManufacturerEntityId = 3,
                        Country = "Taiwan",
                        City = "Taipei",
                        Street = "Beitou district",
                        PostalCode = "100-116",
                    });

            modelBuilder.Entity<ComputerEntity>()
                .HasOne(c => c.Manufacturer);

            modelBuilder.Entity<ComputerEntity>()
                .HasOne(c => c.OperatingSystem);

            modelBuilder.Entity<ComputerEntity>()
                .HasData(
                    new ComputerEntity()
                    {
                        ComputerId = 1,
                        Name = "Gaming computer",
                        ManufacturerId = manufacturerDell.Id,
                        CPU = "Intel Core i9-14900K",
                        RAM = 32,
                        GPU = "GeForce RTX 4090",
                        OperatingSystemId = 1,
                    },
                    new ComputerEntity()
                    {
                        ComputerId = 2,
                        Name = "Office computer",
                        ManufacturerId = manufacturerHp.Id,
                        CPU = "Intel Core i5",
                        RAM = 8,
                        OperatingSystemId = 1,
                    },
                    new ComputerEntity()
                    {
                        ComputerId = 3,
                        Name = "School computer",
                        ManufacturerId = manufacturerAsus.Id,
                        CPU = "Intel core i7",
                        RAM = 8,
                        GPU = "ASUS RADEON HD 7790",
                        OperatingSystemId = 1,
                    }
                );

            modelBuilder.Entity<OperatingSystemEntity>()
                .HasData(
                    new OperatingSystemEntity()
                    {
                        Id = 1,
                        Name = "Windows",
                        Version = "22H2",
                        ReleaseYear = 2015
                    },
                    new OperatingSystemEntity()
                    {
                        Id = 2,
                        Name = "chrome OS",
                        Version = "120.0.6099.235",
                        ReleaseYear = 2011
                    }
                );
        }
    }
}
