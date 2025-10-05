using _Root.Code.GridFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.GridFeature.Application
{
    public class PlaceBuildingUseCase
    {
        private Grid _grid;

        public PlaceBuildingUseCase(Grid grid)
        {
            _grid = grid;
        }

        public void PlaceBuilding(IGhostBuildingPort buildingPort)
        {
            _grid.Place(buildingPort);
        }
    }
}