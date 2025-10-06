using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace _Root.Code.Shared.BuildingPorts
{
    public interface IBuildingRepository
    {
        UniTask<IGhostBuildingPort> GetBuildingAsync(string buildingType);
        
        UniTask<IReadOnlyDictionary<string, IGhostBuildingPort>> GetAllBuildingsAsync();
        
        UniTask SetPlacedBuildingAsync(string buildingType, IGhostBuildingPort ghost);
        
        string GetImageForBuildingUI(string buildingType);
        UniTask<IPlacedBuildingPort> GetPlacedBuildingByTypeAsync(string buildingBuildingType);
    }
}