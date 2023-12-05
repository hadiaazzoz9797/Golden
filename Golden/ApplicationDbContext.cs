using Golden.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golden
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public DbSet<Client>  clients { get; set; }
       
        public DbSet<Details> Details { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Order> orders { get; set; }    
 
        public DbSet<Project> projects { get; set; }
        public DbSet<ProResponsible> proResponsible { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Responsible> Responsible { get; set; }

    }
}
