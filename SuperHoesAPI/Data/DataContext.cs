using Microsoft.EntityFrameworkCore;

namespace SuperHoesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperHoe> SuperHoes { get; set; }
    }
}
