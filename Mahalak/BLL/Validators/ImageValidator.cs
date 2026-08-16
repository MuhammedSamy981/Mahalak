namespace Mahalak;
public static class ImageValidator
{
    public static string IsImagesValid(IEnumerable<IFormFile> files)
    {

        var MaxFileSize = 2 * 1024 * 1024;
        var AllowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

        if (files == null || !files.Any())
        {
            return "يجب عليك أضافة صور للمنتج";
        }

        if (files.Count() !=3)
        {
            return "برجاء أختيار 3 صور للمنتج";
        }

        foreach (var file in files)
        {
            // MIME type (security)
            if (!file.ContentType.StartsWith("image/") || !IsImage(file))
            {
                return "جميع أو بعض الملفات المرفوعة ليست صور";
            }

            // Extension
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
            {
                return $"يجب أن تكون الصور من هذا الأنواع فقط: {string.Join(" - ", AllowedExtensions).Replace(".","")}";
            }

            // File size
            if (file.Length > MaxFileSize)
            {
                return $"حجم كل صورة يجب أن لا يزيد عن {MaxFileSize / 1024 / 1024} ميجا";
            }

        }

        return string.Empty;
    }

    private static bool IsImage(IFormFile file)
    {
        using var reader = new BinaryReader(file.OpenReadStream());
        var signatures = new Dictionary<string, List<byte[]>>
        {
            { "jpeg", new List<byte[]> { new byte[] { 0xFF, 0xD8, 0xFF } } },
            { "png",  new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47 } } },
            { "gif",  new List<byte[]> { new byte[] { 0x47, 0x49, 0x46, 0x38 } } },
            { "bmp",  new List<byte[]> { new byte[] { 0x42, 0x4D } } },
            { "webp", new List<byte[]> { new byte[] { 0x52, 0x49, 0x46, 0x46 } } },
        };

        var headerBytes = reader.ReadBytes(8);

        return signatures.Values.Any(sig =>
            sig.Any(s => headerBytes.Take(s.Length).SequenceEqual(s)));
    }
}