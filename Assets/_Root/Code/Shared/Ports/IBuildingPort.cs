using _Root.Code.Shared.GridPos;

namespace _Root.Code.Shared.Ports
{
    public interface IBuildingPort
    {
        GripPos Position { get; }
        
        void SetPosition(GripPos pos);
    }
}