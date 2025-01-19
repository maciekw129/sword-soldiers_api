namespace SwordSoldiers.Api.Resources.ImageUpload;

public class ImageUploadService(HttpClient httpClient, IConfiguration config): IImageUploadService
{
    private const string EndpointBase = "https://api.imgbb.com/1/upload";
    
    public async Task<ImgBbResponseDto> UploadImageAsync(byte[] image, string imageName)
    {
        using var imageContent = new ByteArrayContent(image);
      
        var form = new MultipartFormDataContent();
        form.Add(imageContent, "image", imageName);

        var response = await httpClient.PostAsync($"{EndpointBase}?key={config["Key:Imgbb"]}", form);
        
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ImgBbResponseDto>();
    }

    public async Task<byte[]> GetImageAsByteArray(IFormFile image)
    {
        using var memoryStream = new MemoryStream();
        await image.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}