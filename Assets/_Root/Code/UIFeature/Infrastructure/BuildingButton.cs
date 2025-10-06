using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.UIFeature.Infrastructure
{
    public class BuildingButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _border;
        [SerializeField] private Image _image;
        public string BuildingKey { get; private set; }
        public Button.ButtonClickedEvent OnClick => _button.onClick;


        public void SetBorderOn()
        {
            _border.SetActive(true);
        }

        public void SetBorderOff()
        {
            _border.SetActive(false);
        }

        public void SetBuildingType(string buildingKey)
        {
            BuildingKey = buildingKey;
        }

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}