using _Root.Code.Shared.BuildingPorts;

namespace _Root.Code.UIFeature.Application
{
    public class SetBuildingToPlaceUseCase
    {
        private IGhostBuildingMover _ghostBuildingMover;
        private IBuildingRepository _buildingRepository;

        public SetBuildingToPlaceUseCase(IGhostBuildingMover ghostBuildingMover, IBuildingRepository buildingRepository)
        {
            _ghostBuildingMover = ghostBuildingMover;
            _buildingRepository = buildingRepository;
        }

        public void SetGhostBuilding(IGhostBuildingPort ghostBuildingPort, string buildingKey)
        {
            _ghostBuildingMover.SetGhostBuilding(ghostBuildingPort, buildingKey);
        }
    }
}