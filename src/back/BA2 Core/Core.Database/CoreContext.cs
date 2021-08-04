using Core.Data.Entities;
using Core.Unity.Config;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class CoreContext : DbContext
    {
        bool _disposed;

        static string DbConnectionString { get; set; }

        public CoreContext()
        { }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }



        public void setDbConnectionString(string connectionString)
        {
            DbConnectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Console.Error.WriteLine("ERR - DbContext is not configured. Configuring...");
                var connString = DbConnectionString;
                optionsBuilder
//                    .UseLoggerFactory(MyConsoleLoggerFactory)
                    .EnableSensitiveDataLogging(false)
                    .UseSqlServer(connString, options => options.MaxBatchSize(150));
            }
            else
            {
                Console.Out.WriteLine("DbContext correctly configured.");
            }
        }

        public DbSet<Arena> Arenas { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public override void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }

            base.Dispose();
        }
    }
}
