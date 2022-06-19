using Microsoft.EntityFrameworkCore;
using OpenseaAPI.DataAccess.Models;

namespace OpenseaAPI.DataAccess.MyDbContext
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<CarouselImg> CarouselImg { get; set; }
        public virtual DbSet<DetailsInfo> DetailsInfo { get; set; }
        public virtual DbSet<ArticleInfo> ArticleInfo { get; set; }
        public virtual DbSet<MenuInfo> MenuInfo { get; set; }
        public virtual DbSet<ImgInfo> ImgInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OracleModelSettings(modelBuilder);
            modelBuilder.Entity<Test>().HasKey(x => x.Id);
            modelBuilder.Entity<CarouselImg>().HasKey(x => x.CarouselId);
            modelBuilder.Entity<DetailsInfo>().HasKey(x => x.DetailsId);
            modelBuilder.Entity<ArticleInfo>().HasKey(x => x.ArticleId);
            modelBuilder.Entity<MenuInfo>().HasKey(x => x.MenuId);
            modelBuilder.Entity<ImgInfo>().HasKey(x => x.ImgId);
        }

        /// <summary>
        /// 将实体表跟栏位转为全大写
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void OracleModelSettings(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entity.Name, builder =>
                {
                    builder.ToTable(entity.ClrType.Name.ToUpper());
                    foreach (var property in entity.GetProperties())
                    {
                        builder.Property(property.Name).HasColumnName(property.Name.ToUpper());
                    }
                });
            }
        }
    }
}
