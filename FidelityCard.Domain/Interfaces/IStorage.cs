namespace FidelityCard.Domain.Interfaces;

public interface IStorage
{
    Stream DownloadFile(string container, string fileName);
    Task<string> UploadFile(string container, Stream content, string fileExtension);
    void DeleteFile(string container, string fileName);
}