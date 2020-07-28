using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QASchool.Selenium_Tests
{
    class Basic
    {
        [Test]
        public void TypaData()
        {
            string firstName = "Sam";
            string lastName = "Conor";

            int age = 30;
            bool isStudent = false;
            double weight = 75.5;
            int salartJul = 15;
            int salaryOct = 20;
            double salaryNov = 45.65;

            int sumsalary = salartJul + salaryOct;

            //Console.WriteLine("Name: " + name);
            //Console.WriteLine("Age: " + age);
            //Console.WriteLine("Is student: " + isStudent);
            //Console.WriteLine("Weight: " + weight);
            //Console.WriteLine("Sam of salaries " + sumsalary);
            //Console.WriteLine("Full Name " + firstName + " " + lastName);

            if(isStudent)
            {
                Console.WriteLine("Sam is student");
            }
            else
            {
                Console.WriteLine("Sam isn't student");
            }
            Console.WriteLine("Test was finished");
        }

        [Test]
        public void SwitchTest()
        {
            SelectSex(Sex.Male);
        }

        public enum Sex { Female, Male }

        public enum Days
        {
            Monday,
            Thuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public void SelectSex(Sex sex)
        {
            switch(sex)
            {
                case Sex.Female:
                    Console.WriteLine("Select Female option in dropDown");
                    break;
                case Sex.Male:
                    Console.WriteLine("Select Male option in dropDown");
                    break;
            }
        }

        [Test]
        public void ForLoop()
        {
            for(int i = 1; i< 10; i++)
            {
                if(i.Equals(5))
                {
                    continue;
                }
                Console.WriteLine("Number " + i);
            }
        }

        [Test]
        public void ListT()
        {
            List<string> names = new List<string>() { "Sam", "Tom", "Mike", "Sara" };
            names.Insert(0, "Mike");
            string name = "Sara";
            names.Insert(3, name);
            int countOfNames = names.Count;
            names.Remove("Sara");
            names.RemoveAt(0);
            countOfNames = names.Count;
            Console.WriteLine("Count of names = " + countOfNames);
            for (int k = 0; k < names.Count; k++)
            {
                Console.WriteLine(names[k]);
            }

            names.Sort();
            Console.WriteLine("Show objects after sorting");
            for (int k = 0; k < names.Count; k++)
            {
                string currentName = names[k];
                if (currentName.Equals("Mike"))
                {
                    names.RemoveAt(k);
                    Console.WriteLine("Object with value 'Mike' was removed from list");
                }
                Console.WriteLine(names[k]);
            }
        }

        [Test]
        public void ArrayList()
        {
            ArrayList namesAndAges = new ArrayList() { "Mike", 2};
            List<string> names = new List<string>() { "Sam", "Tom", "Mike", "Sara" };
            namesAndAges.Add(names);
            namesAndAges.Add(56);
            foreach (object o in namesAndAges)
            {
                Console.WriteLine(o);
            }
        }

        [Test]
        public void Dictionary()
        {
            Dictionary<string, string> namesAndRoles = new Dictionary<string, string>() { { "Mike", "Admin" } };
            namesAndRoles.Add("Sam", "Manager");

            //foreach (KeyValuePair<string, string> keyValue in namesAndRoles)
            //{
            //    Console.WriteLine("Name of user: " + keyValue.Key + ". He/she has role: " + keyValue.Value);
            //}

            //foreach (string key in namesAndRoles.Keys)
            //{
            //    Console.WriteLine(key);
            //}

            namesAndRoles.Remove("Mike");

            foreach (string roles in namesAndRoles.Values)
            {
                Console.WriteLine(roles);
            }

        }                 
    }
}
