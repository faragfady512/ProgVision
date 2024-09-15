using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVision.BLL.Utilities
{
    public static class ConvertIFormFileToByteArray
    {
        public static async Task<byte[]> Convert(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }

    //public static class ConvertIFormFileToByteArray : ITypeConverter<IFormFile, byte[]>
    //{
    //    public static byte[] Convert(IFormFile source, byte[] destination, ResolutionContext context)
    //    {
    //        if (source == null || source.Length == 0)
    //        {
    //            return null;
    //        }

    //        using (var memoryStream = new MemoryStream())
    //        {
    //            source.CopyTo(memoryStream);
    //            return memoryStream.ToArray();
    //        }
    //    }
    //}
}
