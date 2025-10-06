using _Root.Code.BuildingFeature.Application;
using _Root.Code.Shared.BuildingPorts;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class BuildingSpawner
    {
        private DiContainer _container;
        private PlaceBuildingUseCase _placeBuilding;

        public BuildingSpawner(DiContainer container, PlaceBuildingUseCase placeBuilding)
        {
            _container = container;
            _placeBuilding = placeBuilding;
        }
        
        public IPlacedBuildingPort PlaceBuilding(IPlacedBuildingPort building, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var placedBuilding = _container.InstantiatePrefabForComponent<IPlacedBuildingPort>(building as PlacedBuilding, position, rotation, parent);
            (placedBuilding as PlacedBuilding).transform.SetParent(parent); 
            _placeBuilding.PlaceBuilding(placedBuilding.GridPos);
            return placedBuilding;
        }
    }
}