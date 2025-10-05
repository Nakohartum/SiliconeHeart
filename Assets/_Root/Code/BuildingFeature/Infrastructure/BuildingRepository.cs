using System.Collections.Generic;
using System.Linq;
using _Root.Code.BuildingFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class BuildingRepository
    {
        private readonly string _filePath = "Buildings/BuildingConfigs.json";
        private List<BuildingModel> _buildings;
        private IReadable _readable;

        public BuildingRepository(IReadable readable)
        {
            _readable = readable;
            _buildings = _readable.ReadFromJson<BuildingModelConfigs>(_filePath).BuildingModels.ToList();
        }

        public async UniTask<IGhostBuildingPort> GetBuildingAsync(string buildingType)
        {
            var model = _buildings.Find(b=> b.BuildingType == buildingType);
            var go = await Addressables.LoadAssetAsync<GameObject>(model.GhostBuildingName).ToUniTask();
            var building = go.GetComponent<GhostBuilding>();
            return building;
        }

        public async UniTask SetPlacedBuildingAsync(string buildingType, IGhostBuildingPort ghost)
        {
            var model = _buildings.Find(b => b.BuildingType == buildingType);
            var go  = await Addressables.LoadAssetAsync<GameObject>(model.RealBuildingPath).ToUniTask();
            var realBuilding = go.GetComponent<IPlacedBuildingPort>();
            ghost.SetBuildingToBuild(realBuilding);
        }
    }
}