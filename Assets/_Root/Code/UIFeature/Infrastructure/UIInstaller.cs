using _Root.Code.UIFeature.Application;
using UnityEngine;
using Zenject;

namespace _Root.Code.UIFeature.Infrastructure
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIPort _uiPort;
        [SerializeField] private DeleteItem _deleteItem;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DeleteItem>().FromInstance(_deleteItem).AsSingle().NonLazy();
            Container.Bind<SetBuildingToPlaceUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIPort>().FromInstance(_uiPort).AsSingle().NonLazy();
        }
    }
}