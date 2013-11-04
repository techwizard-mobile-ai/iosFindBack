namespace FindBack.Core.Services.DataStore
{
    public interface IImageStorageService
    {
        string SaveImageToFile(byte[] pictureBytes);
    }
}