using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace InsanKaynaklari.UI.Managers
{
    public static class FileManager
    {
        public static string GetUniqueNameAndSavePhotoToDisk(this IFormFile pictureFile, IWebHostEnvironment webHostEnvironment)
        {
            string uniqeFileName = default;

            if (pictureFile is not null)
            {
                uniqeFileName = Guid.NewGuid().ToString() + "-" + pictureFile.FileName;

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, uniqeFileName);

                var fileStream = new FileStream(filePath, FileMode.Create);
                
                    pictureFile.CopyTo(fileStream);
                
            }

            return uniqeFileName;
        }

        public static void RemoveImageFromDisk(string imageName, IWebHostEnvironment webHostEnvironment)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, imageName);
                File.Delete(filePath);
            }
        }
    }
}
