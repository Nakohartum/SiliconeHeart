using Cysharp.Threading.Tasks;

namespace _Root.Code.Shared.AddressablesPort
{
    public interface IAddressablesHelper
    {
        UniTask<T> GetTAsync<T>(string path);
    }
}