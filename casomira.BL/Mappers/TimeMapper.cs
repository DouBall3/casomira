using System;
using System.Collections.Generic;
using System.Text;
using casomira.BL.Factories;
using casomira.BL.Models;
using casomira.DAL.Entities;
using casomira.DAL.Interfaces;

namespace casomira.BL.Mappers
{
    internal static class TimeMapper
    {
        public static TimeModel MapToDetailModel(TimeEntity entity) =>
            entity == null
                ? null
                : new TimeModel()
                {
                    Id = entity.Id,
                    Discipline = entity.Discipline,
                    Time = entity.Time,
                    Team = TeamMapper.MapToDetailModel(entity.Team),
                    Person = PersonMapper.MapToDetailModel(entity.Person)
                };

        public static TimeModel MapToListModel(TimeEntity entity) =>
            entity == null
                ? null
                : new TimeModel()
                {
                    Id = entity.Id,
                    Discipline = entity.Discipline,
                    Time = entity.Time,
                    Team = TeamMapper.MapToDetailModel(entity.Team),
                    Person = PersonMapper.MapToDetailModel(entity.Person)
                };

        public static TimeEntity MapToEntity(TimeModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new DummyEntityFactory()).Create<TimeEntity>(detailModel.Id);
            entity.Id = detailModel.Id;
            entity.Discipline = detailModel.Discipline;
            entity.Time = detailModel.Time;
            entity.Person = PersonMapper.MapToEntity(detailModel.Person, entityFactory);
            entity.Team = TeamMapper.MapToEntity(detailModel.Team, entityFactory);
            return entity;
        }
    }
}
