using casomira.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace casomira.BL.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        void Delete(PersonModel detailModel);
        void Delete(Guid id);
        PersonModel GetById(Guid entityId);
        PersonModel InsertOrUpdate(PersonModel detailModel);
        IEnumerable<PersonModel> GetAll();
    }
}
