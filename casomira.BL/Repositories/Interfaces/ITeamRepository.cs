using System;
using System.Collections.Generic;
using casomira.BL.Models;

namespace casomira.BL.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        void Delete(TeamModel detailModel);
        void Delete(Guid id);
        TeamModel GetById(Guid entityId);
        TeamModel InsertOrUpdate(TeamModel detailModel);
        IEnumerable<TeamModel> GetAll();
    }
}
