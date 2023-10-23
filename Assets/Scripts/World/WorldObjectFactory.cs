using UnityEngine;

namespace World
{
    public class WorldObjectFactory
    {
        private readonly WorldObjectConfig _worldObjectConfig;

        public WorldObjectFactory(WorldObjectConfig worldObjectConfig) => _worldObjectConfig = worldObjectConfig;

        public GameObject Create() => UnityEngine.Object.Instantiate(_worldObjectConfig.WorldObjectPrefab);
    }
}