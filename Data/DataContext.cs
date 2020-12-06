using Task_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<_Task> Tasks { get; set; }
    }
}