using System.IO;
using _Root.Code.DataFeature.Domain;
using _Root.Code.Shared.DataPorts;
using _Root.Code.Shared.GridPos;

namespace _Root.Code.DataFeature.Application
{
    public class SaveWorldUseCase
    {
        private IGrid _grid;
        private WorldState _state;
        private IWritable _writable;

        public SaveWorldUseCase(IGrid grid, WorldState state, IWritable writable)
        {
            _grid = grid;
            _state = state;
            _writable = writable;
        }

        public void Save(string savePath)
        {
            _writable.WriteToJson(savePath, new SaveData
            {
                Buildings = _state.Buildings.ToArray(),
                OccupiedCells = _grid.GetOccupiedCells().ToArray()
            });
        }
    }
    
    
}