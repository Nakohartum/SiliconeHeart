using _Root.Code.GridFeature.Application;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using Grid = _Root.Code.GridFeature.Domain.Grid;

namespace _Root.Code.GridFeature.Infrastructure
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private float _cellSize;
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        [SerializeField] private GridPort _gridPort;

        public override void InstallBindings()
        {
            Container.Bind<Grid>().AsSingle().WithArguments(_width, _height, _cellSize).NonLazy();
            Container.Bind<CheckForPlacementUseCase>().AsSingle().NonLazy();
            Container.Bind<PlaceBuildingUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GridPort>().FromInstance(_gridPort).AsSingle().NonLazy();
        }
    }
}