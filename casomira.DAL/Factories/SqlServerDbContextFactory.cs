using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using casomira.DAL.Interfaces;

namespace casomira.DAL.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory
    { 
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public MeasurementDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MeasurementDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new MeasurementDbContext(optionsBuilder.Options);
        }
    }
}
