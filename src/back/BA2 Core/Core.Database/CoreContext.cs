using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        bool _disposed;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
