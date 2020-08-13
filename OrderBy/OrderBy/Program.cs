using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>{
                new Book { Name = "Book1" , Category=BookCategory.Classics} ,
                new Book { Name = "Book2" , Category=BookCategory.Detective},
                new Book { Name = "Book3" , Category=BookCategory.Horror},
                new Book { Name = "Book4" , Category=BookCategory.Horror},
                new Book { Name = "Book5" , Category=BookCategory.Detective},
            };
            writeBooksByCategory(books);
            IEnumerable<GroupCountByCategory> groupCountByCategory = getGroupCountByCategory(books);
            Console.WriteLine("\n\n");
            writeGroupCountByCategory(groupCountByCategory);
        }

        private static void writeGroupCountByCategory(IEnumerable<GroupCountByCategory> groupCountByCategory)
        {
            foreach (GroupCountByCategory item in groupCountByCategory)
            {
                Console.WriteLine($"Category : {item.Category} , Count : {item.Count}");
            }
        }

        private static IEnumerable<GroupCountByCategory> getGroupCountByCategory(List<Book> books)
        {
            return books.
                            GroupBy(book => book.Category).
                            Select(group => new GroupCountByCategory
                            {
                                Category = group.Key,
                                Count = group.Count()
                            });
        }

        private static void writeBooksByCategory(List<Book> books)
        {
            // --- groups is a list of group
            var groups = books.GroupBy(book => book.Category);

            // --- group is a list of Books with the same category
            foreach (var group in groups)
            {
                // --- key is what we grouped by , Category in this case
                Console.WriteLine($"group.Key : {group.Key} , group.Count() : {group.Count()}");
                foreach (var g in group)
                {
                    Console.Write($"{g.Name} ");
                }
                Console.WriteLine();
            }
        }
    }
}



