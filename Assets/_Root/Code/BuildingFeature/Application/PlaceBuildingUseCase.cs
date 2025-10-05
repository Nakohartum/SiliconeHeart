using _Root.Code.BuildingFeature.Domain;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.BuildingFeature.Application
{
    public class PlaceBuildingUseCase
    {
        private BuildingState _state;

        public PlaceBuildingUseCase(BuildingState state)
        {
            _state = state;
        }

        public void PlaceBuilding(GridPos gridPos)
        {
            _state.Position = gridPos;
        }
    }
}