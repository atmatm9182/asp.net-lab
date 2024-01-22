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
        public DbSet<SoftwareConfigurationEntity> SoftwareConfigurations { get; set; }
        public DbSet<SoftwareApplicationEntity> Applications { get; set; }
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

            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);

            PasswordHasher<IdentityUser> hasher = new();

            var user = new IdentityUser()
            {
                UserName = "pudzian@wsei.edu.pl",
                Email = "pudzian@wsei.edu.pl",
                NormalizedEmail = "PUDZIAN@WSEI.EDU.PL",
                EmailConfirmed = true,
                Id = Guid.NewGuid().ToString(),
            };
            user.PasswordHash = hasher.HashPassword(user, "1AdAbAcAdAbA_!@");

            modelBuilder.Entity<IdentityUser>()
                .HasData(user);
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id,
                });

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
                .HasOne(c => c.Configuration);

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
                        ConfigurationId = 1,
                    },
                    new ComputerEntity()
                    {
                        ComputerId = 2,
                        Name = "Office computer",
                        ManufacturerId = manufacturerHp.Id,
                        CPU = "Intel Core i5",
                        RAM = 8,
                        ConfigurationId = 2,
                    },
                    new ComputerEntity()
                    {
                        ComputerId = 3,
                        Name = "School computer",
                        ManufacturerId = manufacturerAsus.Id,
                        CPU = "Intel core i7",
                        RAM = 8,
                        GPU = "ASUS RADEON HD 7790",
                        ConfigurationId = 3,
                    }
                );

            modelBuilder.Entity<ComputerEntity>()
                .HasOne(c => c.Configuration)
                .WithMany(c => c.Computers)
                .HasForeignKey(c => c.ConfigurationId);

            var excel = new SoftwareApplicationEntity()
            {
                Id = 1,
                Name = "Microsoft Excel",
                Version = "2309"
            };
            var word = new SoftwareApplicationEntity()
            {
                Id = 2,
                Name = "Microsoft Word",
                Version = "2209"
            };
            var gimp = new SoftwareApplicationEntity()
            {
                Id = 3,
                Name = "GIMP",
                Version = "2.10.36"
            };
            var lazarus = new SoftwareApplicationEntity()
            {
                Id = 4,
                Name = "Lazarus",
                Version = "3.0"
            };

            modelBuilder.Entity<SoftwareConfigurationEntity>()
                .HasMany(sc => sc.InstalledApplications)
                .WithMany(a => a.Configurations)
                .UsingEntity<SoftwareConfigurationApplicationEntity>(
                    l => l.HasOne<SoftwareApplicationEntity>().WithMany().HasForeignKey(e => e.ApplicationId),
                    r => r.HasOne<SoftwareConfigurationEntity>().WithMany().HasForeignKey(e => e.ConfigurationId)
                );

            modelBuilder.Entity<SoftwareConfigurationEntity>()
                .HasData(
                    new SoftwareConfigurationEntity()
                    {
                        Id = 1,
                        OperatingSystem = "Windows",
                    },
                    new SoftwareConfigurationEntity()
                    {
                        Id = 2,
                        OperatingSystem = "Windows",
                    },
                    new SoftwareConfigurationEntity()
                    {
                        Id = 3,
                        OperatingSystem = "Windows",
                    }
                    );

            modelBuilder.Entity<SoftwareApplicationEntity>()
                .HasData(excel, word, gimp, lazarus);

            modelBuilder.Entity<SoftwareConfigurationApplicationEntity>()
                .HasData(
                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 1,
                    ApplicationId = 2,
                },
                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 2,
                    ApplicationId = 1,
                },
                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 2,
                    ApplicationId = 2,
                },

                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 3,
                    ApplicationId = 1,
                },

                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 3,
                    ApplicationId = 2,
                },

                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 3,
                    ApplicationId = 3,
                },
                new SoftwareConfigurationApplicationEntity()
                {
                    ConfigurationId = 3,
                    ApplicationId = 4,
                }
                );
        }
    }
}
