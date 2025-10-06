using System;
using System.Numerics;

namespace _Root.Code.Shared.BuildingPorts
{
    public interface IInputPort
    {
        GridPos.GridPos GridMousePosition { get; }
        Vector2  MousePositionWorld { get; }
        event Action OnClick;
    }
}