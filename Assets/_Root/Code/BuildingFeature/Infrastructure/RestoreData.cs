using _Root.Code.BuildingFeature.Application;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class RestoreData : IRestoreData
    {
        private IDataRepository _dataRepository;
        private IBuildingRepository _buildingRepository;
        private BuildingSpawner _buildingSpawner;

        public RestoreData(IDataRepository dataRepository, BuildingSpawner buildingSpawner, IBuildingRepository buildingRepository)
        {
            _dataRepository = dataRepository;
            _buildingSpawner = buildingSpawner;
            _buildingRepository = buildingRepository;
        }
        
        public async UniTask Restore()
        {
            var saveData = _dataRepository.Load();
            foreach (var building in saveData.Buildings)
            {
                var buildingByType = await _buildingRepository.GetPlacedBuildingByTypeAsync(building.BuildingType);
                var placeBuilding = _buildingSpawner.PlaceBuilding(buildingByType, new Vector3(building.GridPos.X, building.GridPos.Y, 0), Quaternion.identity);
                _dataRepository.AddBuilding(building.BuildingType, placeBuilding);
            }
        }
    }
}