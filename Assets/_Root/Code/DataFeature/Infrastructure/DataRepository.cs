using System.Collections.Generic;
using System.Linq;
using _Root.Code.DataFeature.Application;
using _Root.Code.DataFeature.Domain;
using _Root.Code.Shared.BuildingPorts;
using _Root.Code.Shared.DataPorts;

namespace _Root.Code.DataFeature.Infrastructure
{
    public class DataRepository : IDataRepository
    {
        private SaveWorldUseCase _saveWorldUseCase;
        private LoadWorldUseCase _loadWorldUseCase;
        private WorldState _saveWorldState;
        
        private readonly string _savePath = "Savings/Save.txt";
        private SaveData _data;

        public DataRepository(SaveWorldUseCase saveWorldUseCase, WorldState saveWorldState, LoadWorldUseCase loadWorldUseCase)
        {
            _saveWorldUseCase = saveWorldUseCase;
            _saveWorldState = saveWorldState;
            _loadWorldUseCase = loadWorldUseCase;
        }

        public void Save()
        {
            _saveWorldUseCase.Save(_savePath);
        }

        public SaveData Load()
        {
            if (_data == null)
            {
                _data = _loadWorldUseCase.Load(_savePath);
            }

            return _data;
        }

        public void RemoveBuilding(IPlacedBuildingPort placedBuildingPort)
        {
            var building = _saveWorldState.Buildings.First(b => b.GridPos.Equals(placedBuildingPort.GridPos));
            _saveWorldState.Buildings.Remove(building);
        }

        public void AddBuilding(string buildingType, IPlacedBuildingPort building)
        {
            _saveWorldState.Buildings.Add(new BuildingSnapshot
            {
                BuildingType = buildingType,
                GridPos = building.GridPos,
                Size = building.Size
            });
        }
    }
}