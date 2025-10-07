using _Root.Code.Shared.BuildingPorts;

namespace _Root.Code.Shared.DataPorts
{
    public interface IDataRepository
    {
        void Save();
        void AddBuilding(string buildingType, IPlacedBuildingPort building);
        SaveData Load();
        void RemoveBuilding(IPlacedBuildingPort placedBuildingPort);
    }
}