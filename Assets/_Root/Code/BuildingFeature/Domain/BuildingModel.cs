using System;

namespace _Root.Code.BuildingFeature.Domain
{
    [Serializable]
    public class BuildingModel
    {
        public string BuildingType;
        public string GhostBuildingName;
        public string GhostBuildingSprite;
        public string RealBuildingPath;
        public float Cost;
        
    }

    [Serializable]
    public class BuildingModelConfigs
    {
        public BuildingModel[] BuildingModels;
    }
}