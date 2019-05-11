using System.Collections.Generic;
using System.Linq;
using DatesAvailableApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DatesAvailableApi.Services
{
    public class DatesAvailableService
    {
        private readonly IMongoCollection<DatesAvailable> _dates;

        public DatesAvailableService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("DatesAvailableDb"));
            var database = client.GetDatabase("DatesAvailableDb");
            _dates = database.GetCollection<DatesAvailable>("Dates");
        }

        public List<DatesAvailable> Get()
        {
            return _dates.Find(date => true).ToList();
        }

        public DatesAvailable Get(string id)
        {
            return _dates.Find<DatesAvailable>(date => date.Id == id).FirstOrDefault();
        }

        public DatesAvailable Create(DatesAvailable date)
        {
            _dates.InsertOne(date);
            return date;
        }

        public void Update(string id, DatesAvailable dateIn)
        {
            _dates.ReplaceOne(date => date.Id ==id, dateIn);
        }

        public void Remove(DatesAvailable dateIn)
        {
            _dates.DeleteOne(date => date.Id == dateIn.Id);
        }

        public void Remove(string id)
        {
            _dates.DeleteOne(date => date.Id == id);
        }
    }
}