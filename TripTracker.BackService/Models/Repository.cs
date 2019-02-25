using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker.BackService.Models
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
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
            };

        public List<Trip> Get()
        {
            return MyTrips;
        }
        public Trip Get(int Id)
        {
            return MyTrips.First(t=>t.Id==Id);
        }
        public void Add(Trip trip)
        {
            MyTrips.Add(trip);
        }

        public void Update(Trip trip)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == trip.Id));
            Add(trip);
        }

        public void Remove(int Id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == Id));
        }

    }
}
