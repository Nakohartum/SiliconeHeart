using _Root.Code.Shared.BuildingPorts;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class GhostBuildingMover : MonoBehaviour, ITickable
    {
        private IInputPort _inputPort;
        private IGhostBuildingPort  _ghostBuildingPort;

        [Inject]
        private void Construct(IInputPort inputPort)
        {
            _inputPort = inputPort;
            _inputPort.OnClick += PlaceBuilding;
        }

        private void PlaceBuilding()
        {
            _ghostBuildingPort.Place(out var _);
        }

        public void SetGhostBuilding(IGhostBuildingPort ghostBuildingPort)
        {
            _ghostBuildingPort = ghostBuildingPort;
        }


        public void Tick()
        {
            if (_ghostBuildingPort == null)
            {
                return;
            }
            var pos = _inputPort.MousePosition;
            _ghostBuildingPort.Move(pos);
        }
    }
}