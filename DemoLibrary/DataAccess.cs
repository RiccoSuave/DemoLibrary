using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class InitializationException : Exception
    {
        //public string Message { get; set; }
        public InitializationException() { }
        public InitializationException (string message) : base(message) { }
        public InitializationException (string messsage, Exception inner) : base (messsage, inner) { }
    }
    public static class DataAccess
    {
        private static string personTextFile = @"C:\Users\zohal\source\repos\unit testing source\DemoLibrary\PersonText.txt";

        //public static object Message { get; private set; }

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = new List<PersonModel>();
            try
            {
                people = GetAllPeople();
            }
            catch (FileNotFoundException e)
            {

            }
            AddPersonToPeopleList(people, person);
            List<string> lines = ConvertModelsToCSV(people);
            File.WriteAllLines(personTextFile, lines);
            //string createText = "Hello and Welcome" + Environment.NewLine;
            //string path = "personTextFile";
            //File.WriteAllText(path, createText);
        }
            

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", "LastName");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            List<string> output = new List<string>();
            if (people.Count == 0)
            {
                throw new InitializationException ("Collection is empty");
            }

            foreach (PersonModel user in people)
            {
                output.Add($"{ user.FirstName },{ user.LastName }");
            }

            return output;
        }

        public static List<PersonModel> GetAllPeople()
        {
            List<PersonModel> output = new List<PersonModel>();
            string[] content = File.ReadAllLines(personTextFile);

            foreach (string line in content)
            {
                string[] data = line.Split(',');
                output.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
            }

            return output;
        }
    }
}
