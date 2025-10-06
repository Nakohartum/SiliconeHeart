using _Root.Code.GridFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.GridFeature.Application
{
    public class DeleteBuildingUseCase
    {
        private Grid _grid;

        public DeleteBuildingUseCase(Grid grid)
        {
            _grid = grid;
        }

        public void DeleteBuilding(GridPos pos, Size size)
        {
            _grid.Remove(pos, size);
        }
    }
}