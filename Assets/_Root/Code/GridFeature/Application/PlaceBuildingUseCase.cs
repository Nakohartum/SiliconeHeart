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

        public void PlaceBuilding(GridPos pos, Size size)
        {
            _grid.Place(pos, size);
        }

        public void RestoreData(GridPos pos)
        {
            _grid.Place(pos, new Size{X = 1, Y = 1});
        }
    }
}