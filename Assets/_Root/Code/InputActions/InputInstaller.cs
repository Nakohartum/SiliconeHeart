using UnityEngine;
using Zenject;

namespace _Root.Code.InputActions
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputPort _inputPort;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputPort>().FromInstance(_inputPort).AsSingle().NonLazy();
        }
    }
}