using Cysharp.Threading.Tasks;

namespace _Root.Code.Shared.DataPorts
{
    public interface IRestoreData
    {
        UniTask Restore();
    }
}