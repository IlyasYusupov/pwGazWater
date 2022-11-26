using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using Microsoft.AspNetCore.Components.Forms;

namespace pwGazWater.Data
{
    public class FileSystemService
    {
        public void UploadImageToDb(IBrowserFile file, string path)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("ImagesIlyas");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream($"{path}", FileMode.Open))
            {
                gridFS.UploadFromStream($"{file.Name}", fs);
            }
        }

        public void UploadImageToUserDb(IBrowserFile file, string path)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("UserImagesIlyas");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream($"{path}", FileMode.Open))
            {
                gridFS.UploadFromStream($"{file.Name}", fs);
            }
        }

        //public void DownloadToLocal(User user, string path)
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("UserImagesIlyas");
        //    var gridFS = new GridFSBucket(database);
        //    using (FileStream fs = new FileStream(path, FileMode.CreateNew))
        //    {
        //        gridFS.DownloadToStreamByName(user.Photo, fs);
        //    }
        //}
    }
}
