namespace _Root.Code.Shared.DataPorts
{
    public interface IReadable
    {
        T ReadFromJson<T>(string filePath);
    }
}