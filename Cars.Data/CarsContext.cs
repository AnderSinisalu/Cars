﻿using Microsoft.EntityFrameworkCore;
using Cars.Core.Domain;

namespace Cars.Data
{
    public class CarsContext : DbContext
    {
        public CarsContext(DbContextOptions<CarsContext> options) : base(options) { }
        public DbSet<Cars> Cars { get; set; }
    }
}