using System;
using System.Collections.Generic;
using System.Linq;

namespace VsLinqIssue
{
    class Program
    {
        public class Book
        {
            public int Id { get; set; }

            public int OwnerId { get; set; }

            public string Name { get; set; }
        }

        public class Person
        {
            public int Id { get; set; }

            public string Nickname { get; set; }
        }

        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    OwnerId = 1,
                    Name = "Book1"
                },
                new Book
                {
                    Id = 2,
                    OwnerId = 1,
                    Name = "Book2"
                }
            };

            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Nickname = "Person1"
                }
            };

            var join = persons.Join(books, person => person.Id, book => book.OwnerId/*There is no intellisense*/, (person, book) => new
            {
                person.Id,
                person.Nickname,
                book.Name/*There is no intellisense*/
            });

            var groupJoin = persons.GroupJoin(books, person => person.Id, book => book.OwnerId/*There is no intellisense*/, (person, books) => new
             {
                person.Id,
                Name = books.Select(s=>s.Name)
             });

            Console.WriteLine("Hello World!");
        }
    }
}
