using _Root.Code.DataFeature.Application;
using _Root.Code.DataFeature.Domain;
using Zenject;

namespace _Root.Code.DataFeature.Infrastructure
{
    public class DataInfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<WorldState>().AsSingle().NonLazy();
            Container.Bind<SaveWorldUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DataRepository>().AsSingle().NonLazy();
            Container.Bind<LoadWorldUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JsonReader>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JsonWriter>().AsSingle().NonLazy();
        }
    }
}