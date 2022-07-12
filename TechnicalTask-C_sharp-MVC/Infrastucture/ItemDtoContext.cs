using Microsoft.EntityFrameworkCore;
using TechnicalTask_C_sharp_MVC.MdelsDTO;

namespace TechnicalTask_C_sharp_MVC.Infrastucture
{
    public class ItemDtoContext:DbContext
    {
        public DbSet<ItemDTO> Items { get; set; }
        public ItemDtoContext(DbContextOptions<ItemDtoContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
    }
}
