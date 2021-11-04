using PlatformService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public class AppsDbContext:DbContext
    {
      
        public AppsDbContext(DbContextOptions<AppsDbContext> options) : base(options)
        {
        }
        public DbSet<Platform> Platforms { get; set; }

    }
}
