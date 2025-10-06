using _Root.Code.BuildingFeature.Infrastructure;
using _Root.Code.Shared.AddressablesPort;
using _Root.Code.Shared.BuildingPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _Root.Code.Shared.AddressablesHelper
{
    public class AddressablesHelper : IAddressablesHelper
    {
        public async UniTask<T> GetTAsync<T>(string path)
        {
            var go = await Addressables.LoadAssetAsync<T>(path).ToUniTask();
            return go;
        }
    }
}