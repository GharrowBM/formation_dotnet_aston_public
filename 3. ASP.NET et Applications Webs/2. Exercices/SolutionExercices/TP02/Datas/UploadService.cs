namespace TP02.Datas
{
    public class UploadService : IUploadService
    {
        IWebHostEnvironment _webHostEnvironment;

        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            Directory.CreateDirectory(Path.Combine(_webHostEnvironment.WebRootPath, "avatars"));
            string alteredName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "avatars", alteredName);
            Stream stream = System.IO.File.Create(path);
            file.CopyTo(stream);
            stream.Close();
            string finalPath = "avatars/" + alteredName;
            return finalPath;
        }
    }
}
