using _Root.Code.BuildingFeature.Application;
using _Root.Code.BuildingFeature.Domain;
using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class GhostBuildingInstaller : MonoInstaller
    {
        [SerializeField] private GhostBuilding _ghostBuilding;
        public override void InstallBindings()
        {
            Container.Bind<CheckForPlacementUseCase>().AsSingle().NonLazy();
            Container.Bind<MoveGhostBuildingUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GhostBuilding>().FromInstance(_ghostBuilding).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingSpawner>().AsSingle().NonLazy();
        }
    }
}