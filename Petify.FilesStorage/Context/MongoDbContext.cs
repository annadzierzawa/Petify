using System;
using MongoDB.Driver;

namespace Petify.FilesStorage.Context
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public bool IsDbContextConnected { get; }

        public MongoDbContext(
            MongoDbSettings settings)
        {
            try
            {
                var client = new MongoClient(settings.ConnectionString);
                Database = client.GetDatabase(settings.Database);
                IsDbContextConnected = true;
            }
            catch (Exception)
            {
                IsDbContextConnected = false;
            }
        }
    }
}
