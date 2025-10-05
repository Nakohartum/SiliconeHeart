namespace _Root.Code.Shared.DataPorts
{
    public interface IWritable
    {
        void WriteToJson<T>(string filePath, T data);
    }
}