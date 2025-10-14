using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace PortfolioWebsite.Helpers
{
    public interface IImageHelper
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string folderPath, int? maxWidth = null, int? maxHeight = null);
        Task<string> ResizeImageAsync(string imagePath, int width, int height);
        void DeleteImage(string imagePath);
        bool IsValidImage(IFormFile file);
    }

    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _environment;

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile, string folderPath, int? maxWidth = null, int? maxHeight = null)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            if (!IsValidImage(imageFile))
                throw new ArgumentException("Invalid image file");

            var uploadsFolder = Path.Combine(_environment.WebRootPath, folderPath);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            if (maxWidth.HasValue || maxHeight.HasValue)
            {
                await ResizeAndSaveImageAsync(imageFile, filePath, maxWidth, maxHeight);
            }
            else
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }

            return $"/{folderPath}/{uniqueFileName}";
        }

        public async Task<string> ResizeImageAsync(string imagePath, int width, int height)
        {
            var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/'));

            if (!System.IO.File.Exists(fullPath))
                throw new FileNotFoundException("Image not found");

            var resizedFileName = $"resized_{width}x{height}_{Path.GetFileName(imagePath)}";
            var resizedPath = Path.Combine(Path.GetDirectoryName(fullPath), resizedFileName);

            using (var image = await Image.LoadAsync(fullPath))
            {
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(width, height),
                    Mode = ResizeMode.Max
                }));

                await image.SaveAsync(resizedPath, new JpegEncoder { Quality = 80 });
            }

            return $"/{Path.GetDirectoryName(imagePath).Replace("\\", "/")}/{resizedFileName}";
        }

        public void DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/'));

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                return false;

            try
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task ResizeAndSaveImageAsync(IFormFile imageFile, string filePath, int? maxWidth, int? maxHeight)
        {
            using (var image = await SixLabors.ImageSharp.Image.LoadAsync(imageFile.OpenReadStream()))
            {
                if (maxWidth.HasValue || maxHeight.HasValue)
                {
                    var options = new ResizeOptions
                    {
                        Size = new Size(maxWidth ?? 0, maxHeight ?? 0),
                        Mode = ResizeMode.Max
                    };

                    image.Mutate(x => x.Resize(options));
                }

                await image.SaveAsync(filePath, new JpegEncoder { Quality = 80 });
            }
        }

        public static string GetImageDimensions(string imagePath, IWebHostEnvironment environment)
        {
            try
            {
                var fullPath = Path.Combine(environment.WebRootPath, imagePath.TrimStart('/'));
                using (var image = Image.Load(fullPath))
                {
                    return $"{image.Width}x{image.Height}";
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        public static long GetImageFileSize(string imagePath, IWebHostEnvironment environment)
        {
            try
            {
                var fullPath = Path.Combine(environment.WebRootPath, imagePath.TrimStart('/'));
                var fileInfo = new FileInfo(fullPath);
                return fileInfo.Length;
            }
            catch
            {
                return 0;
            }
        }
    }
}
