using Microsoft.EntityFrameworkCore;
using SchoolOlympiads.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolOlympiads.InfrastructureServices.Gateways.Database
{
    public class OlympiadContext : DbContext
    {
        public DbSet<Olympiad> Olympiads { get; set; }

        public OlympiadContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Olympiad>().HasData(
                new
                {
                    Id = 1L,
                    Name = "Всероссийская олимпиада по технологии",
                    Subject = "Технология ",
                    Type = "Всероссийская олимпиада",
                    Class = "7 - 11",
                    Year = 2015

                },
                new
                {
                    Id = 2L,
                    Name = "Математический праздник",
                    Subject = "Математика",
                    Type = "Московская олимпиада",
                    Class = "6 - 7",
                    Year = 2016

                },
                new
                {
                    Id = 3L,
                    Name = "Московская астрономическая олимпиада",
                    Subject = "Астрономия",
                    Type = "Московская олимпиада",
                    Class = "5 - 11",
                    Year = 2016
                },
                new
                {
                    Id = 4L,
                    Name = "Московская математическая олимпиада",
                    Subject = "Математика",
                    Type = "Московская олимпиада",
                    Class = "5 - 11",
                    Year = 2016
                }
            );
        }
    }
}
