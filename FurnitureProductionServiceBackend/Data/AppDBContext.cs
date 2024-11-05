using Microsoft.EntityFrameworkCore;
using FurnitureProductionServiceBackend.Models;

namespace FurnitureProductionServiceBackend.Data
{
    public class FurnitureProductionContext : DbContext
    {
        public FurnitureProductionContext(DbContextOptions<FurnitureProductionContext> options) : base(options)
        {
        }

        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<ManufactureSpecialization> ManufactureSpecializations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<FurnitureCollection> FurnitureCollections { get; set; }
        public DbSet<FurnituresProduction> FurnituresProductions { get; set; }
        public DbSet<ProductionStatus> Statuses { get; set; }
        public DbSet<EmployeeSpecialization> EmployeeSpecializations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacture>()
                .HasOne(m => m.City)
                .WithMany(c => c.Manufactures)
                .HasForeignKey(m => m.CityId);

            modelBuilder.Entity<Manufacture>()
                .HasOne(m => m.ManufactureSpecialization)
                .WithMany(ms => ms.Manufactures)
                .HasForeignKey(m => m.ManufactureSpecializationId);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Manufactures)
                .WithOne(m => m.City)
                .HasForeignKey(m => m.CityId);

            modelBuilder.Entity<ManufactureSpecialization>()
                .HasMany(ms => ms.Manufactures)
                .WithOne(m => m.ManufactureSpecialization)
                .HasForeignKey(m => m.ManufactureSpecializationId);

            modelBuilder.Entity<Furniture>()
                .HasMany(f => f.Materials)
                .WithMany(m => m.Furnitures)
                .UsingEntity(j => j.ToTable("MaterialsInFurniture"));

            modelBuilder.Entity<Furniture>()
                .Property(f => f.Cost)
                .HasColumnType("decimal(18,2)"); 

            modelBuilder.Entity<Material>()
                .Property(m => m.Cost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Furniture>()
                .HasOne(f => f.FurnitureCollection)
                .WithMany(fc => fc.Furnitures)
                .HasForeignKey(f => f.FurnitureCollectionId);

            modelBuilder.Entity<FurnitureCollection>()
                .HasMany(fc => fc.Furnitures)
                .WithOne(f => f.FurnitureCollection)
                .HasForeignKey(f => f.FurnitureCollectionId);

            modelBuilder.Entity<FurnituresProduction>()
                .HasMany(fp => fp.Employees)
                .WithMany(e => e.FurnituresProductions)
                .UsingEntity(j => j.ToTable("InvolvedEmployees"));

            modelBuilder.Entity<ProductionStatus>()
                .HasMany(ps => ps.FurnituresProductions)
                .WithOne(fp => fp.Status)
                .HasForeignKey(fp => fp.StatusId);

            modelBuilder.Entity<EmployeeSpecialization>()
                .HasMany(es => es.Employees)
                .WithOne(e => e.EmployeeSpecialization)
                .HasForeignKey(e => e.SpecializationId);

            modelBuilder.Entity<Manufacture>()
                .HasMany(m => m.Employees)
                .WithOne(e => e.Manufacture)
                .HasForeignKey(e => e.ManufactureId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
