using _Root.Code.Shared.Common;

namespace _Root.Code.Shared.BuildingPorts
{
    public interface IPlacedBuildingPort
    {
        GridPos.GridPos GridPos { get; }
        Size Size { get; }
    }
}