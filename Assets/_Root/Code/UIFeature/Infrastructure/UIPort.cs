using System;
using System.Collections.Generic;
using _Root.Code.Shared.AddressablesPort;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using _Root.Code.Shared.UI;
using _Root.Code.UIFeature.Application;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace _Root.Code.UIFeature.Infrastructure
{
    public class UIPort : MonoBehaviour, IUIPort
    {
        [SerializeField] private BuildingButton _buildingButtonPrefab;
        [SerializeField] private Transform _buildingButtonParent;
        [SerializeField] private Button _placingButton;
        [SerializeField] private Button _deleteButton;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;
        private DeleteItem _deleteItem;
        private IAddressablesHelper _addressablesHelper;
        private IDataRepository _dataRepository;
        private IBuildingRepository _buildingRepository;
        private SetBuildingToPlaceUseCase _setBuildingToPlaceUseCase;
        private BuildingButton[]  _buildingButtons;
        private IRestoreData _restoreData;
        public Action OnIconClicked { get; private set; }

        [Inject]
        private void Construct(IBuildingRepository buildingRepository, SetBuildingToPlaceUseCase setBuildingToPlaceUseCase, 
            IAddressablesHelper addressablesHelper, DeleteItem deleteItem, IDataRepository dataRepository, IRestoreData restoreData)
        {
            _buildingRepository = buildingRepository;
            _setBuildingToPlaceUseCase = setBuildingToPlaceUseCase;
            _addressablesHelper = addressablesHelper;
            _deleteItem = deleteItem;
            _dataRepository =  dataRepository;
            _restoreData =  restoreData;
            PopulateButtons().Forget();
        }

        private void Start()
        {
            _buildingButtonParent.gameObject.SetActive(false);
            _placingButton.onClick.AddListener(ToggleBuildingMode);
            _deleteButton.onClick.AddListener(ActivateDeleteMode);
            _saveButton.onClick.AddListener(_dataRepository.Save);
            _loadButton.onClick.AddListener(() => _restoreData.Restore().Forget());
        }

        private void ToggleBuildingMode()
        {
            _deleteItem.SetIsDeleting(false);
            _buildingButtonParent.gameObject.SetActive(!_buildingButtonParent.gameObject.activeSelf);
        }

        private void ActivateDeleteMode()
        {
            _deleteItem.SetIsDeleting(true);
            _buildingButtonParent.gameObject.SetActive(false);
            _setBuildingToPlaceUseCase.SetGhostBuilding(null, "");
        }

        private async UniTask PopulateButtons()
        {
            var list = new List<BuildingButton>();
            var buildings = await _buildingRepository.GetAllBuildingsAsync();
            foreach (var building in buildings)
            {
                var button = Instantiate(_buildingButtonPrefab, _buildingButtonParent);
                var sprite = await _addressablesHelper.GetTAsync<Sprite>(_buildingRepository.GetImageForBuildingUI(building.Key));
                button.SetSprite(sprite);
                OnIconClicked += button.SetBorderOn;
                button.SetBuildingType(building.Key);
                button.OnClick.AddListener(() => ClickBuildingButton(building.Value, button.BuildingKey));
                list.Add(button);
            }
            _buildingButtons = list.ToArray();
        }

        private void ClickBuildingButton(IGhostBuildingPort building, string buildingKey)
        {
            foreach (var button in _buildingButtons)
            {
                button.SetBorderOff();
            }
            OnIconClicked?.Invoke();
            _setBuildingToPlaceUseCase.SetGhostBuilding(building, buildingKey);
        }
    }
}