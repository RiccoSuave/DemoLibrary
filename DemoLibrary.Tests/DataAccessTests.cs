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
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();
            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
            //DataAccess.AddPersonToPeopleList(people, newPerson);
            //Assert.True(people.Count == 1);
            //Assert.Contains<PersonModel>(newPerson, people);
        }
        [Theory]
        [InlineData("Tim","Corey","")]
        
        public void AddNewPerson_ShouldWork(string firstName, string lastName, string fullName)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();
            people.Add(newPerson);
            string expected = "Tim,Corey\r\n";
            //List<string> actual = DataAccess.ConvertModelsToCSV(people);
            DataAccess.AddNewPerson(newPerson);
            //string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
            string actual = System.IO.File.ReadAllText(@"C:\Users\zohal\source\repos\unit testing source\DemoLibrary\PersonText.txt");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ConvertModelsToCSV_ShouldFail()
        {
            List<PersonModel> people = new List<PersonModel>();
            Assert.Throws<InitializationException>(() => DataAccess.ConvertModelsToCSV(people));
        }

    }
}
