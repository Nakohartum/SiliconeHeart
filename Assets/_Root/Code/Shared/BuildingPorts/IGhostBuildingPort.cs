using _Root.Code.Shared.Common;

namespace _Root.Code.Shared.BuildingPorts
{
    public interface IGhostBuildingPort
    {
        GridPos.GridPos GridPos { get; }
        Size Size { get; }
        void Move(GridPos.GridPos pos);
        bool Place(out IPlacedBuildingPort placedBuilding);
        void Disable();
        void SetBuildingToBuild(IPlacedBuildingPort placedBuilding);
        void SetBuildingToBuildByKey(string buildingKey);
    }
}