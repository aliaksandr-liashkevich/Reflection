using Net.Lab.Liashkevich.Reflection.Comparer.Creators;
using System;

namespace Net.Lab.Liashkevich.Reflection.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new UserComparerCreator();
            var comparer = creator.Create();

            var person = new Person
            {
                Name = "Alex",
                Age = 12,
                Marks = new int[]
                {
                    10, 9, 7
                },
                Address = new Address
                {
                    Street = "Marks",
                    Room = 123
                }
            };

            var person2 = person.Clone();
            person.Marks = new int[]
            {
                10, 9, 7
            };

            Console.WriteLine(comparer.Compare(person, person2));

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int[] Marks { get; set; }

        public Address Address { get; set; }

        public Person Clone()
        {
            var person = this.MemberwiseClone() as Person;
            person.Address = new Address()
            {
                Street = this.Address.Street,
                Room = this.Address.Room
            };

            return person;
        }
    }

    public class Address
    {
        public string Street { get; set; }

        public int Room { get; set; }
    }
}
