using System;

namespace _Root.Code.Shared.BuildingPorts
{
    public interface IInputPort
    {
        GridPos.GridPos MousePosition { get; }
        event Action OnClick;
    }
}