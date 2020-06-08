using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InteractiveMap.Models
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<Layer> Layers { get; set; }
        public virtual DbSet<LayerDot> LayerDots { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<DescriptionObject> DescriptionObjects { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InteractiveMap;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("MapId").IncrementsBy(1);
            modelBuilder.HasSequence<int>("LayerId").IncrementsBy(1);
            modelBuilder.HasSequence<int>("LayerDotID").IncrementsBy(1);
            modelBuilder.HasSequence<int>("DescriptionId").IncrementsBy(1);
            modelBuilder.HasSequence<int>("DescriptionObjectId").IncrementsBy(1);

            modelBuilder.Entity<Map>().Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR MapId");

            modelBuilder.Entity<Layer>().Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR LayerId");

            modelBuilder.Entity<LayerDot>().Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR LayerDotID");

            modelBuilder.Entity<Description>().Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR DescriptionId");
            
            modelBuilder.Entity<DescriptionObject>().Property(o => o.Id)
                        .HasDefaultValueSql("NEXT VALUE FOR DescriptionObjectId");
           
       
        }
    }
}
