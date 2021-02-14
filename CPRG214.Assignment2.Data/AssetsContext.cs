using CPRG214.Assignment2.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPRG214.Assignment2.Data
{
    public class AssetsContext : DbContext
    {
        // Use the base class' constructor
        public AssetsContext() : base() { }

        // Create public properties for each entity in the model
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        // Configures the data for a specific SQL server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost\SQLEXPRESS;
                                        Database = Assets;
                                        Trusted_Connection = True;");
        }

        // Allows for the seeding of data into the created database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>().HasData(
                new Asset 
                { 
                    Id = 1,
                    TagNumber = "AN449812",
                    AssetTypeId = 1,
                    ManufacturerId = 1,
                    Model = "T9-42X",
                    Description = "IT Helpdesk CPU",
                    SerialNumber = "BA-123456-2021"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "AN276623",
                    AssetTypeId = 1,
                    ManufacturerId = 2,
                    Description = "Sales Staff CPU",
                    SerialNumber = "BA-123741-2021"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "AN863345",
                    AssetTypeId = 2,
                    ManufacturerId = 2,
                    Model = "32s",
                    Description = "IT Helpdesk Monitor",
                    SerialNumber = "BA-124665-2020"
                },
                new Asset
                {
                    Id = 4,
                    TagNumber = "AN449871",
                    AssetTypeId = 3,
                    ManufacturerId = 6,
                    Model = "Voyager Focus",
                    Description = "Reception Phone",
                    SerialNumber = "BA-124832-2020"
                }
            );

            modelBuilder.Entity<AssetType>().HasData(
                new AssetType
                {
                    Id = 1,
                    Name = "Computer",
                },
                new AssetType
                {
                    Id = 2,
                    Name = "Monitor",
                },
                new AssetType
                {
                    Id = 3,
                    Name = "Phone",
                }
            );
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    Id = 1,
                    Name = "Dell",
                },
                new Manufacturer
                {
                    Id = 2,
                    Name = "HP",
                },
                new Manufacturer
                {
                    Id = 3,
                    Name = "Acer",
                },
                new Manufacturer 
                { 
                    Id = 4,
                    Name = "LG",
                },
                new Manufacturer
                {
                    Id = 5,
                    Name = "Avaya",
                },
                new Manufacturer
                {
                    Id = 6,
                    Name = "Polycom",
                },
                new Manufacturer
                {
                    Id = 7,
                    Name = "Cisco",
                }
            );
        }
    }
}
