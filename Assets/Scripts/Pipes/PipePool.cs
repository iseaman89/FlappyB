using System.Collections.Generic;
using UnityEngine;

namespace Pipes
{
    public class PipePool
    {
        private readonly int _amountToPool;
        private readonly PipeFactory _pipeFactory;
        private readonly Updater _updater;
        private readonly PipeConfig _pipeConfig;
        private readonly List<Pipe> _pooledObjects = new ();

        public PipePool(PipeFactory pipeFactory, Updater updater, PipeConfig pipeConfig, int amountToPool = 10)
        {
            _pipeFactory = pipeFactory;
            _updater = updater;
            _pipeConfig = pipeConfig;
            _amountToPool = amountToPool;
        }

        private Pipe InstantiatePoolObject()
        {
            var newObject = _pipeFactory.Create();
            newObject.gameObject.SetActive(false);
            newObject.Configurate(this, _pipeConfig);
            return newObject;
        }

        public void FillPool()
        {
            for (var i = 0; i < _amountToPool; i++)
            {
                AddObjectInPool(InstantiatePoolObject());
            }
        }

        private void AddObjectInPool(Pipe poolObject) => _pooledObjects.Add(poolObject);
    
        public Pipe GetPooledObject()
        {
            foreach (var pipe in _pooledObjects)
            {
                if (pipe.gameObject.activeInHierarchy) continue;
                pipe.gameObject.SetActive(true);
                _updater.AddListener(pipe);
                return pipe;
            }

            var newPipe = InstantiatePoolObject();
            AddObjectInPool(newPipe);
            newPipe.gameObject.SetActive(true);
            _updater.AddListener(newPipe);
            return newPipe;
        }

        public void DeactivatePoolObject(Pipe pipe)
        {
            _updater.RemoveListener(pipe);
            pipe.gameObject.SetActive(false);
        }

        public void DeactivateAll()
        {
            foreach (var pipe in _pooledObjects)
            {
                pipe.gameObject.SetActive(false);
            }
        }
    }
}