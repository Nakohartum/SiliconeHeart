using _Root.Code.Shared.GridPos;

namespace _Root.Code.Shared.Ports
{
    public interface IBuildingInProgressPort
    {
        GripPos Position { get; }
        void SetBuildingToBuild(string buildingName);
        void SetGripPos(GripPos gripPos);
        bool CanBePlaced();
        void Place(string buildingName);
    }
}