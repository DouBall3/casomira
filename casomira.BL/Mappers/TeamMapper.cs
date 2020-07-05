using System;
using System.Collections.Generic;
using System.Text;
using casomira.BL.Factories;
using casomira.BL.Models;
using casomira.DAL.Entities;
using casomira.DAL.Interfaces;

namespace casomira.BL.Mappers
{
    internal static class TeamMapper
    {
        public static TeamModel MapToDetailModel(TeamEntity entity) =>
            entity == null
                ? null
                : new TeamModel()
                {
                    Id = entity.Id,
                    Origin = entity.Origin,
                    Variant = entity.Variant,
                    Category = entity.Category
                };

        public static TeamModel MapToListModel(TeamEntity entity) =>
            entity == null
                ? null
                : new TeamModel()
                {
                    Id = entity.Id,
                    Origin = entity.Origin,
                    Variant = entity.Variant,
                    Category = entity.Category
                };

        public static TeamEntity MapToEntity(TeamModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new DummyEntityFactory()).Create<TeamEntity>(detailModel.Id);
            entity.Id = detailModel.Id;
            entity.Category = detailModel.Category;
            entity.Origin = detailModel.Origin;
            entity.Variant = detailModel.Variant;
            return entity;
        }
    }
}
