using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using Microsoft.AspNetCore.Components.Forms;

namespace pwGazWater.Data
{
    public class FileSystemService
    {
        public void UploadToDb(IBrowserFile file, string path)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("UserBaseGuz");
            var gridFS = new GridFSBucket(database);

            using (FileStream fs = new FileStream($"{path}", FileMode.Open))
            {
                gridFS.UploadFromStream($"{file.Name}", fs);
            }
        }

        //public void DownloadToLocal(string name, string path)
        //{
        //    var client = new MongoClient("mongodb://localhost");
        //    var database = client.GetDatabase("UserImagesIlyas");
        //    var gridFS = new GridFSBucket(database);
        //    using (FileStream fs = new FileStream(path, FileMode.CreateNew))
        //    {
        //        gridFS.DownloadToStreamByName(user, fs);
        //    }
        //}
    }
}
