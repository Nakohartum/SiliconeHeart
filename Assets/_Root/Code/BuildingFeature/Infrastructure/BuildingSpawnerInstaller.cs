using _Root.Code.BuildingFeature.Application;
using _Root.Code.BuildingFeature.Domain;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class BuildingSpawnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BuildingSpawner>().AsSingle().NonLazy();
            Container.Bind<BuildingState>().AsTransient().NonLazy();
            Container.Bind<PlaceBuildingUseCase>().AsSingle().NonLazy();
        }
    }
}