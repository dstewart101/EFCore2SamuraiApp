using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurai();
            SimpleSamuraiQuery();
        }

        private static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais.ToList();

                // or do something like this

                var query = context.Samurais;
                var listOfSamurai = query.ToList();


            }
        }

        private static void InsertMultipleSamurai()
        {
            var karen = new Samurai { Name = "KDot" };
            var fletch = new Samurai { Name = "Fleghnog" };
            var reuben = new Samurai { Name = "Reubs" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(karen, fletch, reuben);
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "DS" };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
    }
}
