using ApiProjeKampi.WebApi.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApiProjeKampi.WebApi.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Chef> Chef { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<YummyEvent> YummyEvent { get; set; }
        public DbSet<Notification> Notification { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=CSAHIN\\MSSQLSERVER2022; database=ApiYummyDb; integrated security=true; MultipleActiveResultSets=true; Trusted_Connection=True; TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}