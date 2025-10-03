using System;
using _Root.Code.Shared.GridPos;
using _Root.Code.Shared.Ports;
using UnityEngine;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BuildingInProgress : MonoBehaviour, IBuildingInProgressPort
    {
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _prohibitedColor;
        [SerializeField] private Color _standardColor;
        public GripPos Position => new(transform.position.x, transform.position.y);
        private Collider2D[] _boxes =  new Collider2D[10];


        public void SetBuildingToBuild(string buildingName)
        {
            
        }

        public void SetGripPos(GripPos gripPos)
        {
            transform.position = new Vector3(gripPos.X, gripPos.Y);
            SetColorDependingOnPlacingAbility(CanBePlaced() ? _standardColor : _prohibitedColor);
        }

        private void SetColorDependingOnPlacingAbility(Color color)
        {
            _spriteRenderer.color = color;
        }

        public bool CanBePlaced()
        {
            int size = Physics2D.OverlapBoxNonAlloc(transform.position, _collider.size, 0f, _boxes);
            return size > 0;
        }

        public void Place(string buildingName)
        {
            if (CanBePlaced())
            {
                
            }
        }
    }
}