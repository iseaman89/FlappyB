using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Pipes
{
    public class PipeSpawner : IUpdateListener
    {
        private readonly PipeConfig _pipeConfig;
        private readonly PipePool _pool;
        private readonly Updater _updater;
        private float _timer;

        public PipeSpawner(PipeConfig pipeConfig, PipePool pool, Updater updater)
        {
            _pipeConfig = pipeConfig;
            _pool = pool;
            _updater = updater;
        }

        public void Start() => _updater.AddListener(this);
        
        public void Stop() => _updater.RemoveListener(this);
        
        private void SpawnPipes()
        {
            var pipe = _pool.GetPooledObject();
            pipe.transform.position = 
                new Vector2(_pipeConfig.SpawnPosX, Random.Range(_pipeConfig.SpawnMinY, _pipeConfig.SpawnMaxY));
        }

        public void Updater(float deltaTime)
        {
            if (_timer > _pipeConfig.SpawnDelay)
            {
                SpawnPipes();
                _timer = 0;
            }
        
            _timer += deltaTime;
        }
    }
}