using System;
using _Root.Code.BuildingFeature.Application;
using _Root.Code.BuildingFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class GhostBuilding : MonoBehaviour, IGhostBuildingPort
    {
        [SerializeField] private BoxCollider2D _collider; 
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private IBuildingRepository _buildingRepository;
        private IPlacedBuildingPort _placedBuilding;
        private CheckForPlacementUseCase _checkForPlacementUseCase;
        private BuildingSpawner _buildingSpawner;
        private MoveGhostBuildingUseCase _moveGhostBuildingUseCase;
        public GridPos GridPos => new GridPos(transform.position.x, transform.position.y);
        public Size Size => new Size { X = (int)_collider.size.x, Y = (int)_collider.size.y };
        

        [Inject]
        public void Construct(CheckForPlacementUseCase checkForPlacementUseCase,  PlaceBuildingUseCase placeBuildingUseCase,  
            MoveGhostBuildingUseCase moveGhostBuildingUseCase, IBuildingRepository buildingRepository, DiContainer container, BuildingSpawner buildingSpawner)
        {
            _checkForPlacementUseCase = checkForPlacementUseCase;
            _moveGhostBuildingUseCase = moveGhostBuildingUseCase;
            _buildingRepository = buildingRepository;
            _buildingSpawner = buildingSpawner;
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

        public void SetBuildingToBuildByKey(string buildingKey)
        {
            _buildingRepository.SetPlacedBuildingAsync(buildingKey, this);
        }

        public bool Place(out IPlacedBuildingPort placedBuilding)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                placedBuilding = null;
                return false;
            }
            if (!_checkForPlacementUseCase.CanBePlaced(this))
            {
                placedBuilding = null;
                return false;
            }
            placedBuilding = _buildingSpawner.PlaceBuilding(_placedBuilding, transform.position, transform.rotation);
            return true;
        }

        public void Disable()
        {
            
        }
    }
}