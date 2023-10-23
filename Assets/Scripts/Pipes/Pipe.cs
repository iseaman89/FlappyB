using UnityEngine;

namespace Pipes
{
    public class Pipe : MonoBehaviour, IUpdateListener
    {
        private PipePool _pool;
        private PipeConfig _pipeConfig;

        public void Updater(float deltaTime)
        {
            CheckIfPipeOutOfScreen();
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(_pipeConfig.DestenationPosX, transform.position.y), _pipeConfig.Speed * deltaTime);
        }
    
        private void CheckIfPipeOutOfScreen()
        {
            if (transform.position.x - _pipeConfig.DestenationPosX <= 0) _pool.DeactivatePoolObject(this);
        }

        public void Configurate(PipePool pool, PipeConfig pipeConfig)
        {
            _pool = pool;
            _pipeConfig = pipeConfig;
        }
    }
}
