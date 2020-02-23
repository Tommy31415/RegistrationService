using Microsoft.EntityFrameworkCore;
using RegistrationService.Models;

namespace RegistrationService.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

    }
}