﻿using Api_Hitss.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Hitss.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Proposta> Proposta { get; set; }
    }
}
