using Microsoft.EntityFrameworkCore;
using SalesApp.Core.Entities;

namespace SalesAppData.Data
{    
    public class SalesAppDbcontext:DbContext
    {
        public SalesAppDbcontext(DbContextOptions<SalesAppDbcontext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;database= SalesDb; Integrated Security = True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BuildCategoryModel(modelBuilder);
            //BuildCoverTypeModel(modelBuilder);
            BuildProductModel(modelBuilder);
        }

        private void BuildProductModel(ModelBuilder modelBuilder)
        {
            var productModelBuilder = modelBuilder.Entity<Product>();

            productModelBuilder.ToTable("products");
            productModelBuilder.HasKey(p => p.Id);



            productModelBuilder.Property<int>(p => p.Id)
                .HasColumnName("product_id")
                .HasColumnType("int")
                .IsRequired(true)
                .UseIdentityColumn(100, 1)
                .HasColumnOrder(0);

            productModelBuilder.Property<string>(p => p.Brand)
                .HasColumnName("product_Brand")
                .HasColumnType("varchar(50)")
                .IsRequired(true)
                .HasColumnOrder(1);

            productModelBuilder.Property<string>(p => p.ModelName)
               .HasColumnName("product_ModelName")
               .HasColumnType("varchar(50)")
               .IsRequired(true)
               .HasColumnOrder(2);

            productModelBuilder.Property<string>(p => p.Description)
               .HasColumnName("product_description")
               .HasColumnType("varchar(max)")
               .IsRequired(false)
               .HasColumnOrder(4);


            productModelBuilder.Property<decimal>(p => p.ReceivingPrice)
                .HasColumnName("product_Receiving_Price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(5);

            productModelBuilder.Property<decimal>(p => p.Price)
                .HasColumnName("product_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(6);

            productModelBuilder.Property<string>(p => p.ImageUrl)
                .HasColumnName("product_image_url")
                .HasColumnType("varchar(max)")
                .IsRequired(false)
                .HasColumnOrder(9);

        //productModelBuilder.Property<int?>(p => p.CategoryId)
        //   .HasColumnName("category_id")
        //   .HasColumnType("int")
        //   .IsRequired(false)
        //   .HasColumnOrder(10);

        //productModelBuilder.Property<int?>(p => p.CoverTypeId)
        //   .HasColumnName("cover_type_id")
        //   .HasColumnType("int")
        //   .IsRequired(false)
        //   .HasColumnOrder(11);

        //productModelBuilder.HasOne(p => p.Category);
        //productModelBuilder.HasOne(p => p.CoverType);
    }

        //    productModelBuilder.Property<int>(p => p.Id)
        //        .HasColumnName("product_id")
        //        .HasColumnType("int")
        //        .IsRequired(true)
        //        .UseIdentityColumn(100,1)
        //        .HasColumnOrder(0);

        //    productModelBuilder.Property<string>(p => p.Name)
        //        .HasColumnName("product_name")
        //        .HasColumnType("varchar(50)")
        //        .IsRequired(true)
        //        .HasColumnOrder(1);

        //    productModelBuilder.Property<int>(p => p.Price)
        //        .HasColumnName("product_price")
        //        .HasColumnType("int")
        //        .IsRequired(true)
        //        .HasColumnOrder(2);

        //    productModelBuilder.Property<DateTime>(p => p.CreatedDateTime)
        //        .HasColumnName("created_On")
        //        .HasColumnType("date")
        //        .IsRequired(true)
        //        .HasDefaultValue(DateTime.Now)
        //        .HasColumnOrder(3);
        
    }
}
