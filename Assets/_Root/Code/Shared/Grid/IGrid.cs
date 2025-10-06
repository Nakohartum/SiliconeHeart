using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;

namespace _Root.Code.Shared.GridPos
{
    public interface IGrid
    {
        bool CanBePlaced(IGhostBuildingPort buildingPort);
        void Place(IGhostBuildingPort buildingPort);
        void Remove(GridPos pos, Size size);
        void ShowGrid();
        void HideGrid();
    }
}