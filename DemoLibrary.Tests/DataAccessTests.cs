using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Theory]
        [InlineData("Tim", "", "LastName")]
        [InlineData("", "Corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string fistName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = fistName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();
            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
            //DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert.True(people.Count == 1);
            //Assert.Contains<PersonModel>(newPerson, people);
        }
        [Fact]
        public void ConvertModelsToCSV_ShouldFail()
        {
            List<PersonModel> people = new List<PersonModel>();
            Assert.Throws<InitializationException>(() => DataAccess.ConvertModelsToCSV(people));
        }

    }
}
