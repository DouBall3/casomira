using System;
using System.Collections.Generic;
using System.Text;
using casomira.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace casomira.DAL.Factories
{
    public class InMemoryDbContextFactory : IDbContextFactory
    {
        private readonly string _testDbName;

        public InMemoryDbContextFactory(string testDbName) => _testDbName = testDbName;

        public MeasurementDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeasurementDbContext>();
            optionsBuilder.UseInMemoryDatabase(_testDbName);

            //optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog = {this.testDbName};MultipleActiveResultSets = True;Integrated Security = True; ");

            optionsBuilder.EnableSensitiveDataLogging();
            return new MeasurementDbContext(optionsBuilder.Options);
        }
    }
}
