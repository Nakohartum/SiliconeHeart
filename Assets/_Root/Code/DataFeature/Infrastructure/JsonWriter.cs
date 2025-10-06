using System.Collections.Generic;
using System.IO;
using _Root.Code.Shared.DataPorts;
using UnityEngine;

namespace _Root.Code.DataFeature.Infrastructure
{
    public class JsonWriter : IWritable
    {
        public string FilePath = UnityEngine.Application.dataPath;
        
        public void WriteToJson<T>(string filePath, T data)
        {
            var fullPath = Path.Combine(FilePath, filePath);
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                
            }
            File.WriteAllText(fullPath, JsonUtility.ToJson(data, true));
        }
    }
}