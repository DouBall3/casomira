using casomira.DAL.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using casomira.DAL;
using casomira.DAL.Entities;
using casomira.DAL.Enums;
using casomira.DAL.Interfaces;
using Xunit;

namespace cesomira.DAL.Tests
{
    public class MeasurementDbContextTests : IDisposable
    {
        private readonly InMemoryDbContextFactory _dbContextFactory =
            new InMemoryDbContextFactory("MeasurementTestMemoryDb");

        private readonly MeasurementDbContext _measurementDbContext;

        public MeasurementDbContextTests()
        {
            _measurementDbContext = _dbContextFactory.CreateDbContext();
            _measurementDbContext.Database.EnsureCreated();
        }

        [Fact]
        public void AddNewTeamPersisted()
        {
            //Assert
            var stonarov = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Stonarov",
                Variant = null,
            };

            var pavlov = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Pavlov",
                Variant = null,
            };

            var dlouhaa = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Dlouha Brtnice",
                Variant = "A",
            };

            var dlouhab = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Dlouha Brtnice",
                Variant = "B",
            };

            //Act
            _measurementDbContext.Team.Add(stonarov);
            _measurementDbContext.Team.Add(pavlov);
            _measurementDbContext.Team.Add(dlouhaa);
            _measurementDbContext.Team.Add(dlouhab);
            _measurementDbContext.SaveChanges();

            //Arrange
            using var dbx = _dbContextFactory.CreateDbContext();
            var fromDbS = dbx.Team.Single(i => i.Id == stonarov.Id);
            var fromDbP = dbx.Team.Single(i => i.Id == pavlov.Id);
            var fromDbDa = dbx.Team.Single(i => i.Id == dlouhaa.Id);
            var fromDbDb = dbx.Team.Single(i => i.Id == dlouhab.Id);
            Assert.Equal(stonarov, fromDbS, TeamEntity.TeamEntityComparer);
            Assert.Equal(pavlov, fromDbP, TeamEntity.TeamEntityComparer);
            Assert.Equal(dlouhaa, fromDbDa, TeamEntity.TeamEntityComparer);
            Assert.Equal(dlouhab, fromDbDb, TeamEntity.TeamEntityComparer);
        }

        [Fact]
        public void AddNewPersonPersisted()
        {
            var person1 = new PersonEntity()
            {
                FirstName = "Pavel",
                LastName = "Novacek",
                Age = 31
            };
            var person2 = new PersonEntity()
            {
                FirstName = "Frantisek",
                LastName = "Svoboda",
                Age = 23
            };
            var person3 = new PersonEntity()
            {
                FirstName = "Lubos",
                LastName = "Kratky",
                Age = 23
            };
            var person4 = new PersonEntity()
            {
                FirstName = "Radim",
                LastName = "Stancl",
                Age = 32
            };
            var person5 = new PersonEntity()
            {
                FirstName = "Jan",
                LastName = "Zach",
                Age = 35
            };
            //Assert
            

            //Act
            _measurementDbContext.Person.Add(person1);
            _measurementDbContext.Person.Add(person2);
            _measurementDbContext.Person.Add(person3);
            _measurementDbContext.Person.Add(person4);
            _measurementDbContext.Person.Add(person5);
            _measurementDbContext.SaveChanges();


            //Arrange
            using var dbx = _dbContextFactory.CreateDbContext();
            var fromDb1 = dbx.Person.Single(i => i.Id == person1.Id);
            var fromDb2 = dbx.Person.Single(i => i.Id == person2.Id);
            var fromDb3 = dbx.Person.Single(i => i.Id == person3.Id);
            var fromDb4 = dbx.Person.Single(i => i.Id == person4.Id);
            var fromDb5 = dbx.Person.Single(i => i.Id == person5.Id);
            Assert.Equal(person1, fromDb1, PersonEntity.PersonEntityComparer);
            Assert.Equal(person2, fromDb2, PersonEntity.PersonEntityComparer);
            Assert.Equal(person3, fromDb3, PersonEntity.PersonEntityComparer);
            Assert.Equal(person4, fromDb4, PersonEntity.PersonEntityComparer);
            Assert.Equal(person5, fromDb5, PersonEntity.PersonEntityComparer);
        }
        
        [Fact]
        public void AddNewPersonToTeamPersisted()
        {
            
            //Assert
            var stonarov = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Stonarov",
                Variant = null,
            };

            var pavlov = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Pavlov",
                Variant = null,
            };

            var dlouhaa = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Dlouha Brtnice",
                Variant = "A",
            };

            var dlouhab = new TeamEntity()
            {
                Category = Category.M,
                Origin = "Dlouha Brtnice",
                Variant = "B",
            };

            var person1 = new PersonEntity()
            {
                FirstName = "Pavel",
                LastName = "Novacek",
                Age = 31,
                Team = dlouhaa
            };
            var person2 = new PersonEntity()
            {
                FirstName = "Frantisek",
                LastName = "Svoboda",
                Age = 23,
                Team = dlouhab
            };
            var person3 = new PersonEntity()
            {
                FirstName = "Lubos",
                LastName = "Kratky",
                Age = 23,
                Team = dlouhab
            };
            var person4 = new PersonEntity()
            {
                FirstName = "Radim",
                LastName = "Stancl",
                Age = 32,
                Team = stonarov
            };
            var person5 = new PersonEntity()
            {
                FirstName = "Jan",
                LastName = "Zach",
                Age = 35,
                Team = stonarov
            };

            //Act


            _measurementDbContext.Team.Add(stonarov);
            _measurementDbContext.Team.Add(pavlov);
            _measurementDbContext.Team.Add(dlouhaa);
            _measurementDbContext.Team.Add(dlouhab);
            _measurementDbContext.SaveChanges();
            _measurementDbContext.Person.Add(person1);
            _measurementDbContext.Person.Add(person2);
            _measurementDbContext.Person.Add(person3);
            _measurementDbContext.Person.Add(person4);
            _measurementDbContext.Person.Add(person5);
            _measurementDbContext.SaveChanges();

            //Arrange
            using var dbx = _dbContextFactory.CreateDbContext();
            var fromDbS = dbx.Team.Single(i => i.Id == stonarov.Id);
            var fromDbP = dbx.Team.Single(i => i.Id == pavlov.Id);
            var fromDbDa = dbx.Team.Single(i => i.Id == dlouhaa.Id);
            var fromDbDb = dbx.Team.Single(i => i.Id == dlouhab.Id);
            var fromDb1 = dbx.Person.Single(i => i.Id == person1.Id);
            var fromDb2 = dbx.Person.Single(i => i.Id == person2.Id);
            var fromDb3 = dbx.Person.Single(i => i.Id == person3.Id);
            var fromDb4 = dbx.Person.Single(i => i.Id == person4.Id);
            var fromDb5 = dbx.Person.Single(i => i.Id == person5.Id);
            Assert.Equal(stonarov, fromDbS, TeamEntity.TeamEntityComparer);
            Assert.Equal(pavlov, fromDbP, TeamEntity.TeamEntityComparer);
            Assert.Equal(dlouhaa, fromDbDa, TeamEntity.TeamEntityComparer);
            Assert.Equal(dlouhab, fromDbDb, TeamEntity.TeamEntityComparer);
            Assert.Equal(person1, fromDb1, PersonEntity.PersonEntityComparer);
            Assert.Equal(person2, fromDb2, PersonEntity.PersonEntityComparer);
            Assert.Equal(person3, fromDb3, PersonEntity.PersonEntityComparer);
            Assert.Equal(person4, fromDb4, PersonEntity.PersonEntityComparer);
            Assert.Equal(person5, fromDb5, PersonEntity.PersonEntityComparer);
        }

        [Fact]
        public void GetHashCodeTests()
        {
            var id = Guid.NewGuid();
            var team = new TeamEntity()
            {
                Category = Category.M,
                Id = id,
                Origin = "Test",
                Variant = ""
            };

            var person = new PersonEntity()
            {
                Team = team,
                LastName = "Prijmeni",
                FirstName = "Jmeno",
                Id = id,
                Age = 25
            };

            Assert.Equal(TeamEntity.TeamEntityComparer.GetHashCode(team), HashCode.Combine(id, "Test", "", Category.M));
            Assert.Equal(PersonEntity.PersonEntityComparer.GetHashCode(person), HashCode.Combine(id, "Jmeno", "Prijmeni", 25, team));
        }

        [Fact]
        public void AddNewTimePersisted()
        {
            var time = new TimeEntity()
            {
                
            };
        }

        public void Dispose() => _measurementDbContext?.Dispose();
    }
}
