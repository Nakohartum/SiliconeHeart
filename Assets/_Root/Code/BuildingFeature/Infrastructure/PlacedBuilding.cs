using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.Common;
using _Root.Code.Shared.GridPos;
using UnityEngine;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlacedBuilding : MonoBehaviour, IPlacedBuildingPort
    {
        [SerializeField] private BoxCollider2D _collider;
        public GridPos GridPos => new GridPos(transform.position.x, transform.position.y);
        public Size Size =>  new Size((int)_collider.size.x, (int)_collider.size.y);
    }
}