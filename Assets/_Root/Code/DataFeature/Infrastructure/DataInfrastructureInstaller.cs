using Zenject;

namespace _Root.Code.DataFeature.Infrastructure
{
    public class DataInfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonReader>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JsonWriter>().AsSingle().NonLazy();
        }
    }
}