using System.Collections.Generic;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.GridFeature.Domain
{
    public class Grid
    {
        public List<GridPos> OccupiedGridPositions =  new();
        public int Width;
        public int Height;
        public float CellSize;

        public Grid(int width, int height, float cellSize)
        {
            Width = width;
            Height = height;
            CellSize = cellSize;
        }

        public bool CanBePlaced(IGhostBuildingPort buildingPort)
        {
            for (int x = 0; x < buildingPort.Size.X; x++)
            {
                for (int y = 0; y < buildingPort.Size.Y; y++)
                {
                    var place = new GridPos(x + buildingPort.GridPos.X, y + buildingPort.GridPos.Y);
                    if (OccupiedGridPositions.Contains(place))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Place(IGhostBuildingPort buildingPort)
        {
            for (int x = 0; x < buildingPort.Size.X; x++)
            {
                for (int y = 0; y < buildingPort.Size.Y; y++)
                {
                    var place = new GridPos(x + buildingPort.GridPos.X, y + buildingPort.GridPos.Y);
                    OccupiedGridPositions.Add(place);
                }
            }
        }
    }
}