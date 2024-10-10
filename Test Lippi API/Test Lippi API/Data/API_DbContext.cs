using Microsoft.EntityFrameworkCore;
using Test_Lippi_API.Models;

namespace Test_Lippi_API.Data
{
    public class API_DbContext : DbContext
    {
        public API_DbContext(DbContextOptions<API_DbContext> options) : base(options) 
        {

        }

        public DbSet<Product> Products{ get; set; }
    }
}
