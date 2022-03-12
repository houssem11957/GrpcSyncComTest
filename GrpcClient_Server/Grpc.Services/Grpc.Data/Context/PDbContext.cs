using Grpc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Data.Context
{
  public   class PDbContext:DbContext
    {
        public PDbContext(DbContextOptions<PDbContext> options):base(options)
        {

        }
      public   DbSet<Project> Projects { get; set; }
    }
}
