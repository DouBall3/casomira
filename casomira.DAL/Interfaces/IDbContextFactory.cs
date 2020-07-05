using System;
using System.Collections.Generic;
using System.Text;

namespace casomira.DAL.Interfaces
{
    public interface IDbContextFactory
    {
        MeasurementDbContext CreateDbContext();
    }
}
