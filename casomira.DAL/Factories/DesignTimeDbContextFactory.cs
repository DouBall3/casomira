using Microsoft.EntityFrameworkCore;
using casomira.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Design;

namespace casomira.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MeasurementDbContext>
    {
        public MeasurementDbContext CreateDbContext(string[] bogus)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MeasurementDbContext>();
            dbContextOptionsBuilder.UseSqlServer(@"
                Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = MeasurementDatabase;
                MultipleActiveResultSets = True;
                Integrated Security = True;");
            return new MeasurementDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
