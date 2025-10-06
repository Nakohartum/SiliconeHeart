using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using _Root.Code.Shared.GridPos;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class GhostBuildingMover : MonoBehaviour, ITickable, IGhostBuildingMover
    {
        private IInputPort _inputPort;
        private IGhostBuildingPort  _ghostBuildingPort;
        private DiContainer _container;
        private string _buildingKey;
        private IDataRepository _dataRepository;
        private IGrid _grid;
        
        [Inject]
        private void Construct(IInputPort inputPort, DiContainer container, IDataRepository dataRepository, IGrid grid)
        {
            _inputPort = inputPort;
            _container = container;
            _dataRepository = dataRepository;
            _grid = grid;
            _inputPort.OnClick += PlaceBuilding;
        }
        
        
        private void PlaceBuilding()
        {
            if (_ghostBuildingPort == null)
            {
                return;
            }
            if(_ghostBuildingPort.Place(out var building))
            {
                _dataRepository.AddBuilding(_buildingKey, building);
                _grid.Place(building);
            }
        }

        public void SetGhostBuilding(IGhostBuildingPort ghostBuildingPort, string buildingKey)
        {
            var res = ghostBuildingPort as GhostBuilding;
            if (_ghostBuildingPort != null)
            {
                Destroy((_ghostBuildingPort as GhostBuilding).gameObject);
                _ghostBuildingPort = null;
            }

            if (res != null)
            {
                _ghostBuildingPort = _container.InstantiatePrefabForComponent<IGhostBuildingPort>(res);
                _buildingKey = buildingKey;
                _ghostBuildingPort.SetBuildingToBuildByKey(_buildingKey);
            }
        }


        public void Tick()
        {
            if (_ghostBuildingPort == null)
            {
                return;
            }
            var pos = _inputPort.GridMousePosition;
            _ghostBuildingPort.Move(pos);
        }
    }
}