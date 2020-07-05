using System;
using System.Collections.Generic;
using System.Text;
using casomira.BL.Mappers;
using casomira.BL.Models;
using casomira.BL.Repositories.Interfaces;
using casomira.DAL.Entities;
using casomira.DAL.Interfaces;
using casomira.DAL.Repositories;

namespace casomira.BL.Repositories
{
    public class TimeRepository : RepositoryBase<TimeEntity, TimeModel, TimeModel>, ITimeRepository
    {
        public TimeRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                TimeMapper.MapToEntity,
                TimeMapper.MapToListModel,
                TimeMapper.MapToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}
