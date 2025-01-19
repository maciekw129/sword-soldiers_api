namespace SwordSoldiers.Api.Resources.ImageUpload;

public interface IImageUploadService
{
    Task<ImgBbResponseDto> UploadImageAsync(byte[] image, string imageName);
    Task<byte[]> GetImageAsByteArray(IFormFile image);
}