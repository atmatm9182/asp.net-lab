using Data.Entities;
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

            modelBuilder.Entity<ComputerEntity>()
                .HasData(
                    new ComputerEntity()
                    {
                        ComputerId = 1,
                        Name = "Gaming computer",
                        Manufacturer = "DELL",
                        CPU = "Intel Core i9-14900K",
                        RAM = 32,
                        GPU = "GeForce RTX 4090",
                    },
                    new ComputerEntity()
                    {
                        ComputerId = 2,
                        Name = "Office computer",
                        Manufacturer = "HP",
                        CPU = "Intel Core i5",
                        RAM = 8,
                    }
                );
        }
    }
}
