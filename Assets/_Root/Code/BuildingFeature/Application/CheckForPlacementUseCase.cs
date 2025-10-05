using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.BuildingFeature.Application
{
    public class CheckForPlacementUseCase
    {
        private IGrid _grid;

        public CheckForPlacementUseCase(IGrid grid)
        {
            _grid = grid;
        }
        public bool CanBePlaced(IGhostBuildingPort ghostBuildingPort)
        {
            return _grid.CanBePlaced(ghostBuildingPort);
        }
    }
}