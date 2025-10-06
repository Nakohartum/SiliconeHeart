using _Root.Code.Shared.DataPorts;

namespace _Root.Code.DataFeature.Application
{
    public class LoadWorldUseCase
    {
        private IReadable _readable;

        public LoadWorldUseCase(IReadable readable)
        {
            _readable = readable;
        }

        public SaveData Load(string filePath)
        {
            return _readable.ReadFromJson<SaveData>(filePath);
        }
    }
}