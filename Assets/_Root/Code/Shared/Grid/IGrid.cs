using _Root.Code.Shared.BuildingPorts;

namespace _Root.Code.Shared.GridPos
{
    public interface IGrid
    {
        bool CanBePlaced(IGhostBuildingPort buildingPort);
        void Place(IGhostBuildingPort buildingPort);
        void ShowGrid();
        void HideGrid();
    }
}