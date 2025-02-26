using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Cars> Cars { get; set; }
        public DbSet<Inquiries> Inquiries { get; set; }
    }
}
