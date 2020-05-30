using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Wilcommerce.Web.AspNetCore.Http
{
    public static class FormFileExtensions
    {
        public static byte[] ToByteArray(this IFormFile file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            using var memoryStream = new MemoryStream();

            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public static async Task<byte[]> ToByteArrayAsync(this IFormFile file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
