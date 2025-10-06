using _Root.Code.BuildingFeature.Application;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class PlacedBuildingInstaller : MonoInstaller
    {
        [SerializeField] private PlacedBuilding _placedBuilding;
        public override void InstallBindings()
        {
            Container.Bind<DeleteBuildingUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlacedBuilding>().FromInstance(_placedBuilding).AsSingle().NonLazy();
        }
    }
}