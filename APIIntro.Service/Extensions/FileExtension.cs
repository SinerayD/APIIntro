using Microsoft.AspNetCore.Http;

namespace APIIntro.Service.Extensions
{
    public static class FileExtension
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("Image");
        }
        public static bool IsSizeOk(this IFormFile file, int mb)
        {
            return file.Length / 1024 / 1024 <= mb;
        }
        public static string SaveFile(this IFormFile file, string root, string path)
        {
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath=Path.Combine(root,FileName);

            using (FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                stream.CopyTo(stream);
            }
            return FileName;    
        }
       
    }
}
