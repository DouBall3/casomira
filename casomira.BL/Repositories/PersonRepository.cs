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
    public class PersonRepository : RepositoryBase<PersonEntity, PersonModel, PersonModel>, IPersonRepository
    {
        public PersonRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory,
                PersonMapper.MapToEntity,
                PersonMapper.MapToListModel,
                PersonMapper.MapToDetailModel,
                null,
                null,
                null)
        {
        }
    }
}
