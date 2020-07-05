using System;
using System.Collections.Generic;
using System.Text;
using casomira.BL.Factories;
using casomira.BL.Models;
using casomira.DAL.Entities;
using casomira.DAL.Interfaces;

namespace casomira.BL.Mappers
{
    internal static class PersonMapper
    {
        public static PersonModel MapToDetailModel(PersonEntity entity) =>
            entity == null
                ? null
                : new PersonModel()
                {
                    Id = entity.Id,
                    LastName = entity.LastName,
                    Team = TeamMapper.MapToDetailModel(entity.Team),
                    FirstName = entity.FirstName,
                    Age = entity.Age
                };

        public static PersonModel MapToListModel(PersonEntity entity) =>
            entity == null
                ? null
                : new PersonModel()
                {
                    Id = entity.Id,
                    LastName = entity.LastName,
                    Team = TeamMapper.MapToDetailModel(entity.Team),
                    FirstName = entity.FirstName,
                    Age = entity.Age
                };

        public static PersonEntity MapToEntity(PersonModel detailModel, IEntityFactory entityFactory)
        {
            var entity = (entityFactory ??= new DummyEntityFactory()).Create<PersonEntity>(detailModel.Id);
            entity.Id = detailModel.Id;
            entity.Age = detailModel.Age;
            entity.FirstName = detailModel.FirstName;
            entity.LastName = detailModel.LastName;
            entity.Team = TeamMapper.MapToEntity(detailModel.Team, entityFactory);
            return entity;
        }
    }
}
