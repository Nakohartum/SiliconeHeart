using _Root.Code.BuildingFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.BuildingFeature.Application
{
    public class MoveGhostBuildingUseCase
    {
        private BuildingState  _state;

        public MoveGhostBuildingUseCase(BuildingState state)
        {
            _state = state;
        }

        public void Move(GridPos pos)
        {
            _state.Position = pos;
        }
    }
}