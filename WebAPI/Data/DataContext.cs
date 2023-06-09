﻿using WebAPI.Model;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {

        }
        public DbSet<Karakter> karakters => Set<Karakter>();
    }
}
