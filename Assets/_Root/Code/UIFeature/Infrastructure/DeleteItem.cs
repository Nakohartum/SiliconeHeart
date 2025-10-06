using System;
using _Root.Code.Shared.BuildingPorts;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace _Root.Code.UIFeature.Infrastructure
{
    public class DeleteItem : MonoBehaviour, ITickable
    {
        private bool _isDeleting = false;
        private IInputPort _inputPort;
        private Camera _cam;
        private IPlacedBuildingPort _hover;

        [Inject]
        private void Construct(IInputPort inputPort)
        {
            _inputPort = inputPort;
            _inputPort.OnClick += Delete;
        }
        
        private void Awake()
        {
            _cam = Camera.main;
        }

        private void Delete()
        {
            if (_hover != null && _isDeleting)
            {
                _hover.Delete();
            }
        }

        public void SetIsDeleting(bool isDeleting)
        {
            _isDeleting = isDeleting;
        }

        public void Tick()
        {
            
            if (!_isDeleting || EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            var world  = _cam.ScreenToWorldPoint(new Vector3(_inputPort.MousePositionWorld.X, _inputPort.MousePositionWorld.Y));
            world.z = 0f;
            var hit = Physics2D.OverlapCircle(world, 0.08f);
            if (hit && hit.TryGetComponent<IPlacedBuildingPort>(out var del))
                SetHover(del);
            else
                ClearHover();
        }

        private void ClearHover()
        {
            if (_hover != null) _hover.OnHover(false);
            _hover = null;
        }

        private void SetHover(IPlacedBuildingPort del)
        {
            if (_hover == del) return;
            ClearHover();
            _hover = del;
            _hover.OnHover(true);
        }
    }
}