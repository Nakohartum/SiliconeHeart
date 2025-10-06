using _Root.Code.BuildingFeature.Application;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlacedBuilding : MonoBehaviour, IPlacedBuildingPort
    {
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private DeleteBuildingUseCase _deleteBuildingUseCase;
        public GridPos GridPos => new GridPos(transform.position.x, transform.position.y);

        public Size Size => new Size
        {
            X = (int)_collider.size.x,
            Y = (int)_collider.size.y
        };

        [Inject]
        private void Construct(DeleteBuildingUseCase deleteBuildingUseCase)
        {
            _deleteBuildingUseCase = deleteBuildingUseCase;
        }
        public void Delete()
        {
            _deleteBuildingUseCase.Delete(GridPos, Size);
            Destroy(gameObject);
        }

        public void OnHover(bool hover)
        {
            _spriteRenderer.color = hover ? Color.red : Color.white;
        }
    }
}