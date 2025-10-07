using System;
using System.Collections.Generic;
using _Root.Code.BuildingFeature.Domain;
using _Root.Code.BuildingFeature.Infrastructure;
using _Root.Code.DataFeature.Infrastructure;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace _Root.Code
{
    public class SceneLoader : MonoBehaviour
    {
        private ZenjectSceneLoader _sceneLoader;

        [Inject]
        private void Construct(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _sceneLoader.LoadSceneAsync("UIScene",  LoadSceneMode.Additive, extraBindings:null, LoadSceneRelationship.Child);
        }
        
    }
}