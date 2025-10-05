using System;
using _Root.Code.BuildingFeature.Application;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class GhostBuilding : MonoBehaviour, IGhostBuildingPort
    {
        [SerializeField] private BoxCollider2D _collider; 
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private IPlacedBuildingPort _placedBuilding;
        public GridPos GridPos => new GridPos(transform.position.x, transform.position.y);
        public Size Size => new Size((int)_collider.size.x, (int)_collider.size.y);
        private CheckForPlacementUseCase _checkForPlacementUseCase;
        private PlaceBuildingUseCase _placeBuildingUseCase;
        private MoveGhostBuildingUseCase _moveGhostBuildingUseCase;

        [Inject]
        public void Construct(CheckForPlacementUseCase checkForPlacementUseCase,  PlaceBuildingUseCase placeBuildingUseCase,  MoveGhostBuildingUseCase moveGhostBuildingUseCase)
        {
            _checkForPlacementUseCase = checkForPlacementUseCase;
            _placeBuildingUseCase = placeBuildingUseCase;
            _moveGhostBuildingUseCase = moveGhostBuildingUseCase;
        }

        public void Move(GridPos pos)
        {
            transform.position = new Vector3(pos.X, pos.Y);
            _spriteRenderer.color = _checkForPlacementUseCase.CanBePlaced(this) ? Color.white : Color.red;
            _moveGhostBuildingUseCase.Move(pos);
        }

        public void SetBuildingToBuild(IPlacedBuildingPort placedBuilding)
        {
            _placedBuilding = placedBuilding;
        }

        public bool Place(out IPlacedBuildingPort placedBuilding)
        {
            if (!_checkForPlacementUseCase.CanBePlaced(this))
            {
                placedBuilding = null;
                return false;
            }
            placedBuilding = Instantiate(_placedBuilding as PlacedBuilding , transform.position, transform.rotation);
            _placeBuildingUseCase.PlaceBuilding(placedBuilding.GridPos);
            return true;
        }

        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }
    }
}