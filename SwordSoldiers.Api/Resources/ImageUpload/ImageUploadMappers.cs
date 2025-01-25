namespace SwordSoldiers.Api.Resources.ImageUpload;

public static class ImageUploadMappers
{
    public static UploadedImageDto ImgBbResponseDtoToUploadedImageDto(this ImgBbResponseDto imgBbResponseDto)
    {
        return new UploadedImageDto()
        {
            FileName = imgBbResponseDto.Data.Image.Filename,
            Extension = imgBbResponseDto.Data.Image.Extension,
            Url = imgBbResponseDto.Data.Image.Url,
            Size = imgBbResponseDto.Data.Size,
        };
    }
}