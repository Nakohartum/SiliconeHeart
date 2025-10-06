using System;
using _Root.Code.Shared.Common;

namespace _Root.Code.Shared.DataPorts
{
    [Serializable]
    public class SaveData
    {
        public BuildingSnapshot[] Buildings;
        public GridPos.GridPos[] OccupiedCells;
    }

    [Serializable]
    public struct BuildingSnapshot
    {
        public GridPos.GridPos GridPos;
        public Size Size;
        public string BuildingType;
    }
}