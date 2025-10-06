using UnityEngine;
using Zenject;

namespace _Root.Code.Shared.AddressablesHelper
{
    public class AddressablesHelperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AddressablesHelper>().AsSingle().NonLazy();
        }
    }
}