using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker.BackService.Models;

namespace TripTracker.BackService.Data
{
    public class TripContext : DbContext
    {

        public DbSet<Trip> Trips { get; set; }
        public TripContext(DbContextOptions<TripContext> options):base(options)
        {

        }
        public TripContext()
        {

        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var servicescope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var context = servicescope.ServiceProvider.GetService<TripContext>();
                context.Database.EnsureCreated();
                if (context.Trips.Any()) return;
                context.Trips.AddRange(new Trip[]
                {
                     new Trip
                {
                    Id=1,
                    Name="MVC Summit",
                    StartDate=new DateTime(2019,2,25),
                    EndDate=new DateTime(2019,2,28)
                },
                new Trip
                {
                    Id=2,
                    Name="Dev Intersection",
                    StartDate=new DateTime(2019,3,20),
                    EndDate=new DateTime(2019,3,25)
                 },
                new Trip
                {
                    Id=3,
                    Name="Build",
                    StartDate=new DateTime(2019,4,25),
                    EndDate=new DateTime(2019,4,29)
                }
                }
                    );
                context.SaveChanges();
            }

        }
    }
}
