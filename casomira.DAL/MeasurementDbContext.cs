using casomira.DAL.Entities;
using casomira.DAL.Enums;
using Microsoft.EntityFrameworkCore;
namespace casomira.DAL
{
    public class MeasurementDbContext : DbContext
    {
        public MeasurementDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<TimeEntity> Time { get; set; }


    }
}
