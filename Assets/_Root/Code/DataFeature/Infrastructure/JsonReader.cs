using System.IO;
using _Root.Code.Shared.DataPorts;
using UnityEngine;

namespace _Root.Code.DataFeature.Infrastructure
{
    public class JsonReader : IReadable
    {
        public string FilePath = Application.dataPath;
        public T ReadFromJson<T>(string filePath)
        {
            var fullPath = Path.Combine(FilePath, filePath);
            if (!File.Exists(fullPath))
            {
                return default(T);
            }
            return JsonUtility.FromJson<T>(File.ReadAllText(fullPath));
        }
    }
}