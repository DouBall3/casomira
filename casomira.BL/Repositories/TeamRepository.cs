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
    public class TeamRepository : RepositoryBase<TeamEntity, TeamModel, TeamModel>, ITeamRepository
    {
        public TeamRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                TeamMapper.MapToEntity,
                TeamMapper.MapToListModel,
                TeamMapper.MapToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}
