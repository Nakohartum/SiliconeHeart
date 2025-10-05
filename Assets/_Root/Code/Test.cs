using System;
using System.Collections.Generic;
using _Root.Code.BuildingFeature.Domain;
using _Root.Code.BuildingFeature.Infrastructure;
using _Root.Code.DataFeature.Infrastructure;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Root.Code
{
    public class Test : MonoBehaviour
    {
        private GhostBuildingMover _ghostBuildingMover;
        private GhostBuilding _ghostBuilding;
        private DiContainer _container;
        private BuildingRepository _buildingRepository;
        private IWritable _writable;

        [Inject]
        private void Construct(GhostBuildingMover ghostBuildingMover, BuildingRepository buildingRepository, DiContainer container,  IWritable writable)
        {
            _ghostBuildingMover = ghostBuildingMover;
            _container = container;
            _buildingRepository = buildingRepository;
            _writable = writable;
        }

        [ContextMenu("SetBuilding")]
        public async UniTask SetBuilding()
        {
            var res = await _buildingRepository.GetBuildingAsync("Test");
            var ghostBuilding = _container.InstantiatePrefabForComponent<IGhostBuildingPort>(res as GhostBuilding);
            await _buildingRepository.SetPlacedBuildingAsync("Test",  ghostBuilding);
            _ghostBuildingMover.SetGhostBuilding(ghostBuilding);
        }
        
    }
}