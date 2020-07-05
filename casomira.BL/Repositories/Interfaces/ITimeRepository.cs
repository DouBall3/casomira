using System;
using System.Collections.Generic;
using casomira.BL.Models;

namespace casomira.BL.Repositories.Interfaces
{
    public interface ITimeRepository
    {
        void Delete(TimeModel detailModel);
        void Delete(Guid id);
        TimeModel GetById(Guid entityId);
        TimeModel InsertOrUpdate(TimeModel detailModel);
        IEnumerable<TimeModel> GetAll();
    }
}
