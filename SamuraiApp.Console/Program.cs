using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Console
{
    class Program
    {

        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            //InsertSamurai();
            //InsertMultipleSamurai();
            //SimpleSamuraiQuery();
            //DSQuery();
            AddSamuraiAndQuotes();
        }

        private static void AddSamuraiAndQuotes()
        {
            var samurai = new Samurai
            {
                Name = "David", Quotes = new List<Quote> {
                    new Quote { Text = "Go on"},
                    new Quote { Text = "Watch out!"}
                }
            };

            _context.Add(samurai);
            _context.SaveChanges();
        }

        private static void DSQuery()
        {
            var name = "DS";
            var DS = _context.Samurais.Where(s => s.Name == name).ToList();
        }

        private static void SimpleSamuraiQuery()
        {
            var samurais = _context.Samurais.ToList();

            // or do something like this

            var query = _context.Samurais;
            var listOfSamurai = query.ToList();

            var sams = query.Where(s => s.Name == "Kdot");
            var karen = sams.ToList();

            //same as all this : 
            // _context.Samurais.Where(s => s.Name == "Kdot").ToList();
        }

        private static void InsertMultipleSamurai()
        {
            var karen = new Samurai { Name = "KDot" };
            var fletch = new Samurai { Name = "Fleghnog" };
            var reuben = new Samurai { Name = "Reubs" };


            _context.Samurais.AddRange(karen, fletch, reuben);
            _context.SaveChanges();
        }

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "DS" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
    }
}
