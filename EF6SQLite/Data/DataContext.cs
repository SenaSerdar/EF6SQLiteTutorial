using Microsoft.EntityFrameworkCore;

namespace EF6SQLite.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<RpgCharacter> RpgCharacter=> Set<RpgCharacter>(); 
    }
}