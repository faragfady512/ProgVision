using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Utilities
{
    public static class ImageUtilities
    {
        public static string SaveImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return null;
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var imagePath = Path.Combine("Assets", "Students", fileName);

            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
            using (var fileStream = new FileStream(wwwrootPath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return imagePath;
        }

        public static string ConvertByteArrayToImageUrl(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }

            // Convert byte array to Base64 string
            string base64String = Convert.ToBase64String(byteArray);

            // Construct Data URL
            string imageUrl = $"data:image/jpeg;base64,{base64String}";

            return imageUrl;
        }

    }
}
