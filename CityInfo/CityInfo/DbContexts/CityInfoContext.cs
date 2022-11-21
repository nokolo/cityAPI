﻿using System;
using CityInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<PointOfInterest> PointOfInterests { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext>options)
            : base(options)
        {

        }

    }
}

