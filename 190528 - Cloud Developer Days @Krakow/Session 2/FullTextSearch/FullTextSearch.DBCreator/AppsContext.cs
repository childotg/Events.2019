using FullTextSearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullTextSearch.DBCreator
{
    public class AppsContext:DbContext
    {
        private readonly string _connectionString = null;
        public AppsContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public AppsContext():this("")
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<AppItem> Applications { get; set; }
    }
}
