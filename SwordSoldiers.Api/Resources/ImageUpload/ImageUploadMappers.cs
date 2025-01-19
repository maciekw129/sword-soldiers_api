namespace SwordSoldiers.Api.Resources.ImageUpload;

public static class ImageUploadMappers
{
    public static ImageUploadResponseDto ImgBbResponseDtoToImageUploadResponseDto(this ImgBbResponseDto imgBbResponseDto)
    {
        return new ImageUploadResponseDto()
        {
            FileName = imgBbResponseDto.Data.Image.Filename,
            Extension = imgBbResponseDto.Data.Image.Extension,
            Url = imgBbResponseDto.Data.Image.Url
        };
    }
}