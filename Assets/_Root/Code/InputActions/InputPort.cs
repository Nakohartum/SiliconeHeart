using System;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.GridPos;
using UnityEngine;

namespace _Root.Code.InputActions
{
    public class InputPort : MonoBehaviour, IInputPort
    {
        [SerializeField] private Grid _unityGrid;
        private PlayerInputActions _playerInputActions;
        private Camera _camera;
        public event Action OnClick;

        private void Awake()
        {
            _camera = Camera.main;
            _playerInputActions = new PlayerInputActions();
        }

        private void Start()
        {
            _playerInputActions.Enable();
            _playerInputActions.BuildingActions.Click.performed += _ => OnClick?.Invoke();
        }

        public GridPos MousePosition
        {
            get
            {
                Vector2 screenPos = _playerInputActions.BuildingActions.MousePosition.ReadValue<Vector2>();
                

                // экран → мир
                Vector3 world = _camera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, -_camera.transform.position.z));
                

                // мир → ячейка → центр
                Vector3Int cell = _unityGrid.WorldToCell(world);
                
                Vector3 snapped = _unityGrid.GetCellCenterWorld(cell);
                return new GridPos(snapped.x, snapped.y);
            }
        }

        
    }
}