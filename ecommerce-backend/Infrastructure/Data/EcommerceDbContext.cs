using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }
        // Entities
    }
}