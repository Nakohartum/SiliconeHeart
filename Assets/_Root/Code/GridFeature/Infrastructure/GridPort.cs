using System.Collections.Generic;
using _Root.Code.GridFeature.Application;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.DataPorts;
using _Root.Code.Shared.GridPos;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace _Root.Code.GridFeature.Infrastructure
{
    public class GridPort : MonoBehaviour, IGrid
    {
        [SerializeField] private Color _gridColor;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Grid _unityGrid;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private string _sortingLayerName;
        private GridFeature.Domain.Grid _grid;
        private CheckForPlacementUseCase  _checkForPlacementUseCase;
        private PlaceBuildingUseCase   _placeBuildingUseCase;
        private DeleteBuildingUseCase  _deleteBuildingUseCase;
        private List<GameObject> _lines = new();

        [Inject]
        private void Construct(GridFeature.Domain.Grid grid, CheckForPlacementUseCase checkForPlacementUseCase,
            PlaceBuildingUseCase placeBuildingUseCase, DeleteBuildingUseCase deleteBuildingUseCase)
        {
            _grid = grid;
            _checkForPlacementUseCase = checkForPlacementUseCase;
            _placeBuildingUseCase = placeBuildingUseCase;
            _deleteBuildingUseCase =  deleteBuildingUseCase;
            CreateLines();
        }


        private void CreateLines()
        {
            var bounds = _tilemap.cellBounds;   

            Vector3 worldMin = _unityGrid.GetCellCenterWorld(bounds.min) - new Vector3(_grid.CellSize, _grid.CellSize) * 0.5f;

            for (int x = 0; x <= _grid.Width; x++)
            {
                Vector3 start = worldMin + new Vector3(x * _grid.CellSize, 0, 0);
                Vector3 end   = start + new Vector3(0, _grid.Height * _grid.CellSize, 0);
                CreateLine(start, end);
            }

            for (int y = 0; y <= _grid.Height; y++)
            {
                Vector3 start = worldMin + new Vector3(0, y * _grid.CellSize, 0);
                Vector3 end   = start + new Vector3(_grid.Width * _grid.CellSize, 0, 0);
                CreateLine(start, end);
            }
        }

        public bool CanBePlaced(IGhostBuildingPort buildingPort)
        {
            
            if (!_checkForPlacementUseCase.CanBePlaced(buildingPort))
            {
                return false;
            }
            var position = new Vector2(buildingPort.GridPos.X, buildingPort.GridPos.Y);
            var size = new Vector2(buildingPort.Size.X, buildingPort.Size.Y);
            var length = Physics2D.OverlapBoxAll(position, size, 0f).Length;
            if (length > 1)
            {
                return false;
            }

            return true;
        }

        public void Place(IPlacedBuildingPort buildingPort)
        {
            _placeBuildingUseCase.PlaceBuilding(buildingPort.GridPos, buildingPort.Size);
        }

        public void Remove(GridPos pos, Size size)
        {
            _deleteBuildingUseCase.DeleteBuilding(pos, size);
        }

        [ContextMenu("ShowGrid")]
        public void ShowGrid()
        {
            foreach (var line in _lines)
            {
                line.SetActive(true);
            }
        }

        [ContextMenu("HideGrid")]
        public void HideGrid()
        {
            foreach (var line in _lines)
            {
                line.SetActive(false);
            }
        }

        public List<GridPos> GetOccupiedCells()
        {
            return _grid.OccupiedGridPositions;
        }

        private void CreateLine(Vector3 start, Vector3 end)
        {
            var go = new GameObject("GridLine", typeof(LineRenderer))
            {
                transform =
                {
                    parent = this.transform
                }
            };
            
            var lr = go.GetComponent<LineRenderer>();

            lr.positionCount = 2;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            lr.startWidth = lr.endWidth = 0.1f;
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = lr.endColor = _gridColor;
            lr.sortingLayerName = _sortingLayerName;
            lr.sortingOrder = 5;
            _lines.Add(go);
        }
    }
}