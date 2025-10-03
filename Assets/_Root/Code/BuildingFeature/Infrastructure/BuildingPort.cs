using _Root.Code.Shared.GridPos;
using _Root.Code.Shared.Ports;
using UnityEngine;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BuildingPort : MonoBehaviour, IBuildingPort
    {
        public GripPos Position => new(transform.position.x, transform.position.y);
        public void SetPosition(GripPos pos)
        {
            transform.position = new Vector2(pos.X, pos.Y);
        }
    }
}