using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Petify.FilesStorage.Context;
using Petify.FilesStorage.Helpers;

namespace Petify.FilesStorage.Repositories.BaseRepositories
{
    public abstract class GridFsRepository : IGridFsRepository
    {
        protected readonly bool IsConnected;
        protected GridFSBucket _gridFs;

        public GridFsRepository(MongoDbContext context, GridFSBucketOptions options)
        {
            if (context.IsDbContextConnected)
            {
                try
                {
                    if (context.Database.ListCollections().ToList().All(x => !x["name"].AsString.Contains(options.BucketName)))
                    {
                        context.Database.CreateCollection($"{options.BucketName}.files");
                        context.Database.CreateCollection($"{options.BucketName}.chunks");
                    }

                    _gridFs = new GridFSBucket(context.Database, options);
                    IsConnected = true;
                }
                catch (Exception)
                {
                    IsConnected = false;
                }
            }
        }

        public Task<ObjectId> Insert(string fileName, Stream stream)
        {
            MakeSureIsConnected();
            return _gridFs.UploadFromStreamAsync(fileName, stream);
        }

        public Task<ObjectId> Insert(string fileName, byte[] byteArray)
        {
            MakeSureIsConnected();
            return _gridFs.UploadFromBytesAsync(fileName, byteArray);
        }

        public Task<ObjectId> Insert(string fileName, byte[] byteArray, string contentType)
        {
            MakeSureIsConnected();

            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    { MongoMetadataNames.ContentType, contentType }
                }
            };

            return _gridFs.UploadFromBytesAsync(fileName, byteArray, options);
        }

        public async Task Insert(ObjectId id, string fileName, byte[] byteArray)
        {
            MakeSureIsConnected();
            using (var stream = await _gridFs.OpenUploadStreamAsync(id, fileName))
            {
                await stream.WriteAsync(byteArray, 0, byteArray.Length);
                await stream.CloseAsync();
            }
        }

        public async Task Insert(ObjectId id, string fileName, Stream stream)
        {
            MakeSureIsConnected();
            using (var mongoStream = await _gridFs.OpenUploadStreamAsync(id, fileName))
            {
                await stream.CopyToAsync(mongoStream);
                await mongoStream.CloseAsync();
            }
        }

        public Task<byte[]> GetContentById(ObjectId id)
        {
            MakeSureIsConnected();
            return _gridFs.DownloadAsBytesAsync(id);
        }

        public async Task<Stream> GetContentById(ObjectId id, Stream destination)
        {
            MakeSureIsConnected();
            await _gridFs.DownloadToStreamAsync(id, destination);
            return destination;
        }

        public async Task<string> GetContentByIdAsString(ObjectId id)
        {
            MakeSureIsConnected();
            byte[] content = await _gridFs.DownloadAsBytesAsync(id);
            return Encoding.UTF8.GetString(content, 0, content.Length);
        }

        public async Task<GridFSDownloadStream> GetStreamById(ObjectId id)
        {
            MakeSureIsConnected();
            return await _gridFs.OpenDownloadStreamAsync(id);
        }

        public async Task<GridFSFileInfo> GetFileInfoById(ObjectId id)
        {
            MakeSureIsConnected();
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", id);
            var fileInfo = await _gridFs.FindAsync(filter);
            var result = await fileInfo.SingleOrDefaultAsync();
            return result;
        }

        public Task Delete(ObjectId id)
        {
            MakeSureIsConnected();
            return _gridFs.DeleteAsync(id);
        }

        private void MakeSureIsConnected()
        {
            if (!IsConnected)
            {
                throw new Exception("MongoDb not connected");
            }
        }
    }
}
