using UnityEngine;
using Zenject;

namespace _Root.Code.BuildingFeature.Infrastructure
{
    public class GhostBuildingMoverInstaller : MonoInstaller
    {
        [SerializeField] private GhostBuildingMover _ghostBuildingMover;
        public override void InstallBindings()
        {
            Container.Bind<BuildingRepository>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GhostBuildingMover>().FromInstance(_ghostBuildingMover).AsSingle().NonLazy();
        }
    }
}