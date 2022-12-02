using Mango.Service.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
namespace Mango.Service.ProductAPI.DBContexts
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
    }
}
