using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VehicleDemoAPI.Models;

namespace VehicleDemoAPI.Controllers
{
    public class VehicleController : ApiController
    {
        //Constructor
        List<Vehicle> car = new List<Vehicle>();
        public VehicleController()
        {
            car.Add(new Vehicle { Id = 1, Year = 2014, Make = "Toyota", Model = "Camry" });
            car.Add(new Vehicle { Id = 2, Year = 2020, Make = "Tesla", Model = "S" });
            car.Add(new Vehicle { Id = 3, Year = 2016, Make = "Ford", Model = "Ranger" });
            car.Add(new Vehicle { Id = 4, Year = 2009, Make = "Honda", Model = "Civic" });
        }
        
        // GET: api/Vehicle
        public List<Vehicle> Get()
        {
            return car;
        }

        // GET: api/Vehicle/5
        public Vehicle Get(int id)
        {
            return car.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Vehicle
        public List<Vehicle> Post(Vehicle entry)
        {
            car.Add(entry);
            return car;
        }

        // PUT: api/Vehicle/5
        public List<Vehicle> Put(int id, Vehicle entry)
        {
            //find the index of the entry you want to modify
            Vehicle updatedCar = car.Find(x => x.Id == id);
            int index = car.IndexOf(updatedCar);

            //replace the values using the newer inputs
            car[index].Year = entry.Year;
            car[index].Make = entry.Make;
            car[index].Model = entry.Model;

            //display the new list of Vehicles
            return car;
        }

        // DELETE: api/Vehicle/5
        public List<Vehicle> Delete(int id)
        {
            //Find the entry you want to delete using the Id
            Vehicle entry = car.Find(x => x.Id == id);

            //Delete the entry and display the new list
            car.Remove(entry);
            return car;
        }
    }
}
