﻿using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EmployeeModel> EmployeeModels { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<PersonModel> PersonModels { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }



    }
}
