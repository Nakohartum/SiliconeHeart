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
    public class Test : MonoBehaviour
    {
        private GhostBuildingMover _ghostBuildingMover;
        private GhostBuilding _ghostBuilding;
        private DiContainer _container;
        private BuildingRepository _buildingRepository;
        private IWritable _writable;
        private ZenjectSceneLoader _sceneLoader;

        [Inject]
        private void Construct(GhostBuildingMover ghostBuildingMover, BuildingRepository buildingRepository, DiContainer container,  IWritable writable, ZenjectSceneLoader sceneLoader)
        {
            _ghostBuildingMover = ghostBuildingMover;
            _container = container;
            _buildingRepository = buildingRepository;
            _writable = writable;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            _sceneLoader.LoadSceneAsync("UIScene",  LoadSceneMode.Additive, extraBindings:null, LoadSceneRelationship.Child);
        }
        
    }
}