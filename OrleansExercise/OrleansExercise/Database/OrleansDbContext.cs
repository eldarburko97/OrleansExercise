using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrleansExercise.Database
{
    public class OrleansDbContext : DbContext
    {
        public OrleansDbContext(DbContextOptions<OrleansDbContext> options) : base(options: options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(data: new List<Student>
            {
                new Student
                {
                    Id = new Guid(g: "CA7F0FC5-97C6-4B2C-809A-DBA2DEA629E4"),
                    FirstName = "Eldor",
                    LastName = "Mujkic",
                    Address = "Gradacacka 13",
                    Phone = "+387 61 764 891"
                },
                new Student
                {
                    Id = new Guid(g: "1166210B-06E6-459B-81EF-49EA0FF2E021"),
                    FirstName = "Edo",
                    LastName = "Mujkic",
                    Address = "Gradacacka 13",
                    Phone = "+387 61 764 891"
                },
                new Student
                {
                    Id = new Guid(g: "6B0CBAE4-4D43-4CB0-AEC5-A259640478C1"),
                    FirstName = "Faris",
                    LastName = "Mujkic",
                    Address = "Gradacacka 13",
                    Phone = "+387 61 764 891"
                },
                new Student
                {
                    Id = new Guid(g: "37CB4F57-4066-46EF-9229-06880EA70BEA"),
                    FirstName = "Kenan",
                    LastName = "Mujkic",
                    Address = "Gradacacka 13",
                    Phone = "+387 61 764 891"
                },
                new Student
                {
                    Id = new Guid(g: "9CAB3C3E-E793-4E5A-9460-732E2F2A68F9"),
                    FirstName = "Admir",
                    LastName = "Mujkic",
                    Address = "Gradacacka 13",
                    Phone = "+387 61 764 891"
                }
            });
            base.OnModelCreating(modelBuilder: modelBuilder);
        }
    }
}