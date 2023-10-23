using UnityEngine;

namespace World
{
    public class WorldObjectMovement : IUpdateListener
    {
        private float _offset;
        private readonly WorldObjectConfig _worldObjectConfig;
        private readonly Updater _updater;
        private readonly Material _material;
        private readonly int _mainTex = Shader.PropertyToID("_MainTex");

        public WorldObjectMovement(WorldObjectConfig worldObjectConfig, Updater updater, Material material)
        {
            _worldObjectConfig = worldObjectConfig;
            _updater = updater;
            _material = material;
        }

        public void Start() => _updater.AddListener(this);

        public void Updater(float deltaTime)
        {
            _offset += (deltaTime * _worldObjectConfig.Speed) / 10f;
            _material.SetTextureOffset(_mainTex, new Vector2(_offset, 0));
        }
    }
}