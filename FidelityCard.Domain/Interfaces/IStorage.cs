namespace FidelityCard.Domain.Interfaces;

public interface IStorage
{
    Stream DownloadFile(string container, string fileName);
    Task<string> UploadFile(string container, Stream content, string originalFileName);
    void DeleteFile(string container, string fileName);
}