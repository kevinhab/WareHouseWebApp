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

            await DB.InitAsync(dbName, MongoClientSettings.FromConnectionString(connString));
        }
    }
}
