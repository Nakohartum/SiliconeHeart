using _Root.Code.Shared.BuildingPorts;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class GhostBuildingMover : MonoBehaviour, ITickable, IGhostBuildingMover
    {
        private IInputPort _inputPort;
        private IGhostBuildingPort  _ghostBuildingPort;
        private DiContainer _container;

        [Inject]
        private void Construct(IInputPort inputPort, DiContainer container)
        {
            _inputPort = inputPort;
            _container = container;
            _inputPort.OnClick += PlaceBuilding;
        }

        private void PlaceBuilding()
        {
            if (_ghostBuildingPort == null)
            {
                return;
            }
            _ghostBuildingPort.Place(out var _);
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
                _ghostBuildingPort.SetBuildingToBuildByKey(buildingKey);
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