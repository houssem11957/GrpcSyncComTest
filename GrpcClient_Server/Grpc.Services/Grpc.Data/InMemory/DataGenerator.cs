using Grpc.Data.Context;
using Grpc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grpc.Data.InMemory
{
  public   class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PDbContext>>()))
            {
                // Look for any Project.
                if (context.Projects.Any())
                {
                    return;   // Data was already seeded
                }

                context.Projects.AddRange(
                    new Project
                    {
                       id=1,
                       Title="project1",
                       Description="Description1"
                    },
                    new Project
                    {
                        id = 2,
                        Title = "project2",
                        Description = "Description2"
                    },
                    new Project
                    {
                        id = 3,
                        Title = "project3",
                        Description = "Description3"
                    },
                     new Project
                     {
                         id = 4,
                         Title = "project4",
                         Description = "Description4"
                     },
                     new Project
                     {
                         id = 5,
                         Title = "project5",
                         Description = "Description5"
                     },
                     new Project
                     {
                         id = 6,
                         Title = "project6",
                         Description = "Description6"
                     },
                    new Project
                    {
                        id = 7,
                        Title = "project7",
                        Description = "Description7"
                    });

                context.SaveChanges();
            }
        }
    }
}
