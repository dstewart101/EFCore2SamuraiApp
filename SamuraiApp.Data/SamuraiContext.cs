﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {

        public static readonly LoggerFactory MyConsoleLoggerFactory
            =   new LoggerFactory( new[] {
                new ConsoleLoggerProvider( (category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information, true ) });


        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }

        public SamuraiContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .UseSqlServer
                (
                "Server = (localdb)\\mssqllocaldb; Database = SamuraiAppData; Trusted_Connection = True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
