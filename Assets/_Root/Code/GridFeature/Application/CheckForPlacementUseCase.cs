using _Root.Code.GridFeature.Domain;
using _Root.Code.Shared.BuildingPorts;

namespace _Root.Code.GridFeature.Application
{
    public class CheckForPlacementUseCase
    {
        private Grid _grid;

        public CheckForPlacementUseCase(Grid grid)
        {
            _grid = grid;
        }

        public bool CanBePlaced(IGhostBuildingPort buildingPort)
        {
            return _grid.CanBePlaced(buildingPort);
        }
    }
}