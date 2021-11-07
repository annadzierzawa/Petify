using System.IO;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace Petify.FilesStorage.Repositories.BaseRepositories
{
    public interface IGridFsRepository
    {
        Task<ObjectId> Insert(string fileName, Stream stream);
        Task<ObjectId> Insert(string fileName, byte[] byteArray);
        Task<ObjectId> Insert(string fileName, byte[] byteArray, string contentType);
        Task Insert(ObjectId id, string fileName, byte[] byteArray);
        Task Insert(ObjectId id, string fileName, Stream stream);
        Task<byte[]> GetContentById(ObjectId id);
        Task<string> GetContentByIdAsString(ObjectId id);
        Task<Stream> GetContentById(ObjectId id, Stream destination);
        Task<GridFSDownloadStream> GetStreamById(ObjectId id);
        Task<GridFSFileInfo> GetFileInfoById(ObjectId id);
        Task Delete(ObjectId id);
    }
}
