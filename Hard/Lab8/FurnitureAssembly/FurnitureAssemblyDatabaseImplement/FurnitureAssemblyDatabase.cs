using FurnitureAssemblyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyDatabaseImplement
{
    public class FurnitureAssemblyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=FurnitureAssemblyDatabaseFull;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<WorkPiece> WorkPieces { set; get; }

        public virtual DbSet<Furniture> Furnitures { set; get; }

        public virtual DbSet<FurnitureWorkPiece> FurnitureWorkPieces { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Shop> Shops { set; get; }

        public virtual DbSet<ShopFurniture> ShopFurnitures { get; set; }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Implementer> Implementers { set; get; }

        public virtual DbSet<MessageInfo> Messages { set; get; }
    }
}
