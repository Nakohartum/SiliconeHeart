using System;
using _Root.Code.Shared.BuildingPorts;

namespace _Root.Code.Shared.UI
{
    public interface IUIPort
    {
        Action OnIconClicked { get; }
    }
}