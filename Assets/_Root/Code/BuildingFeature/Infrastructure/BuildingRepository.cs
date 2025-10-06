using System.Collections.Generic;
using System.Linq;
using _Root.Code.BuildingFeature.Domain;
using _Root.Code.Shared.AddressablesPort;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly string _filePath = "Buildings/BuildingConfigs.json";
        private List<BuildingModel> _buildings;
        private IReadable _readable;
        private IAddressablesHelper _addressablesHelper;
        private DiContainer _container;

        public BuildingRepository(IReadable readable, IAddressablesHelper addressablesHelper, DiContainer container)
        {
            _readable = readable;
            _addressablesHelper = addressablesHelper;
            _container = container;
            _buildings = _readable.ReadFromJson<BuildingModelConfigs>(_filePath).BuildingModels.ToList();
        }

        public async UniTask<IGhostBuildingPort> GetBuildingAsync(string buildingType)
        {
            var model = _buildings.Find(b=> b.BuildingType == buildingType);
            var go = await _addressablesHelper.GetTAsync<GameObject>(model.GhostBuildingName);
            var building = go.GetComponent<GhostBuilding>();
            return building;
        }

        public async UniTask<IReadOnlyDictionary<string, IGhostBuildingPort>> GetAllBuildingsAsync()
        {
            var list = new Dictionary<string, IGhostBuildingPort>();
            foreach (var building in _buildings)
            {
                var build = await GetBuildingAsync(building.BuildingType);
                
                list.Add(building.BuildingType, build);
            }

            return list;
        }

        public async UniTask SetPlacedBuildingAsync(string buildingType, IGhostBuildingPort ghost)
        {
            var model = _buildings.Find(b => b.BuildingType == buildingType);
            var go  =  await _addressablesHelper.GetTAsync<GameObject>(model.RealBuildingPath);
            var realBuilding = go.GetComponent<IPlacedBuildingPort>();
            ghost.SetBuildingToBuild(realBuilding);
        }

        public string GetImageForBuildingUI(string buildingType)
        {
            var model = _buildings.Find(b => b.BuildingType == buildingType);
            return model.GhostBuildingSprite;
        }

        public async UniTask<IPlacedBuildingPort> GetPlacedBuildingByTypeAsync(string buildingType)
        {
            var model = _buildings.Find(b => b.BuildingType == buildingType);
            var go  =  await _addressablesHelper.GetTAsync<GameObject>(model.RealBuildingPath);
            var realBuilding = go.GetComponent<IPlacedBuildingPort>();
            return realBuilding;
        }
    }
}