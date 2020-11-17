using Microsoft.EntityFrameworkCore;
using MyFavoriteBooksSimple.Data;
using System;
using System.Linq;

namespace MyFavoriteBooksSimple
{
    public class Program
    {
        static readonly MyFavoriteBooksContext context = new();
        static void Main()
        {
            DebugView();
            ToQueryString();
        }

        static void DebugView()
        {
            //Put a breakpoint here to see the DebugView in action
            var query = context.Authors
                .Where(f => f.FirstName.Length > 4)
                .Take(2)
                .OrderBy(l => l.LastName)
                .Select(e => new { e.FirstName, e.LastName });

            var list = query.ToList();
        }

        static void ToQueryString()
        {
            var query = context.Authors
                .Where(f => f.FirstName.Length > 4)
                .Take(2)
                .OrderBy(l => l.LastName)
                .Select(e => new { e.FirstName, e.LastName });

            var queryString = query.ToQueryString();

            //Console query string
            Console.WriteLine(queryString);
        }
    }
}
