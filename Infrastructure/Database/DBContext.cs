using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Entities;
using System.Threading.Tasks;

namespace WareHouseProject.Infrastructure.Database
{
    public static class DBContext
    {
        public static async Task InitAsync(IConfiguration configuration)
        {
            var connString = configuration["MongoSettings:ConnectionString"];
            var dbName = configuration["MongoSettings:Database"];

            //await DB.InitAsync(dbName, MongoClientSettings.FromConnectionString(connString));

            if (string.IsNullOrWhiteSpace(connString) || string.IsNullOrWhiteSpace(dbName))
                throw new ArgumentException("MongoDB connection settings are not configured properly.");

            try
            {
                await DB.InitAsync(dbName, MongoClientSettings.FromConnectionString(connString));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not initialize MongoDB connection", ex);
            }

        }
    }
}
