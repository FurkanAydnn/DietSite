using Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCMyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DietContext : IdentityDbContext<ApplicationUser>
    {
        public DietContext() : base("DietContext")
        {

        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<DietList> DietLists { get; set; }
        public virtual DbSet<HealthInfo> HealthInfos { get; set; }
        public virtual DbSet<HealthInfoResult> HealthInfoResults { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<OnlineDietForm> OnlineDietForms { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductConsumption> ProductConsumptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region TableConfiguration

            modelBuilder.Entity<Article>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<DietList>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<HealthInfo>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<HealthInfoResult>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Image>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OnlineDietForm>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProductType>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProductConsumption>()
                .HasKey(x => x.Id);

            #endregion

            #region Relations

            modelBuilder.Entity<Article>()
                .HasMany(x => x.Images)
                .WithMany(x => x.Articles);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.ProductConsumptions)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Product>()
                .HasRequired(x => x.ProductType)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductTypeId);

            modelBuilder.Entity<ProductConsumption>()
                .HasRequired(x => x.OnlineDietForm)
                .WithMany(x => x.ProductConsumptions)
                .HasForeignKey(x => x.OnlineDietFormId);

            modelBuilder.Entity<HealthInfo>()
                .HasMany(x => x.HealthInfoResults)
                .WithRequired(x => x.HealthInfo)
                .HasForeignKey(x => x.HealthInfoId);

            modelBuilder.Entity<HealthInfoResult>()
                .HasRequired(x => x.OnlineDietForm)
                .WithMany(x => x.HealthInfoResults)
                .HasForeignKey(x => x.OnlineDietFormId);


            #endregion
        }

    }
}
