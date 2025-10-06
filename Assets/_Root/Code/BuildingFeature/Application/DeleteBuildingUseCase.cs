using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.BuildingFeature.Application
{
    public class DeleteBuildingUseCase
    {
        private IGrid _grid;

        public DeleteBuildingUseCase(IGrid grid)
        {
            _grid = grid;
        }

        public void Delete(GridPos pos, Size size)
        {
            _grid.Remove(pos, size);
        }
    }
}