using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwordSoldiers.Api.Resources.ImageUpload;

[Route($"{Constants.protectedRoute}/image-upload")]
[ApiController]
public class ImageUploadController(IImageUploadService imageUploadService) : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = "CreateGameMaps")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
    {
        if (image == null || image.Length == 0)
        {
            return BadRequest("Image is empty");
        }
        
        var imageData = await imageUploadService.GetImageAsByteArray(image);
        var response = await imageUploadService.UploadImageAsync(imageData, image.FileName);

        return Ok(response.ImgBbResponseDtoToImageUploadResponseDto());
    }
}