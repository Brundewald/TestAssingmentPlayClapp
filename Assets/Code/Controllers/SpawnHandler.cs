
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Code.Controllers
{
    public class SpawnHandler
    {
        private readonly GameObject _parent;
        private readonly Stack<Rigidbody> _pool;
        private readonly GameObject _cubePrefab;

        public SpawnHandler(GameObject cubePrefab, GameObject parent, int poolSize)
        {
            _cubePrefab = cubePrefab;
            _parent = parent;
            _pool = new Stack<Rigidbody>();
            FillThePool(poolSize);
        }

        private void FillThePool(int poolSize)
        {
            for (var i = 0; i < poolSize; i++)
            {
                _pool.Push(CreateCube());
            }
        }

        public Rigidbody GetFromPool()
        {
            if (!_pool.Any()) return null;
            var spawnCube = _pool.Pop();
            spawnCube.gameObject.SetActive(true);
            return spawnCube;
        }

        public void ReturnToPool(Rigidbody cubeRigidbody)
        {
            cubeRigidbody.gameObject.SetActive(false);
            cubeRigidbody.velocity = Vector3.zero;
            cubeRigidbody.transform.position = _parent.transform.position;
            _pool.Push(cubeRigidbody);
        }

        private Rigidbody CreateCube()
        {
            var cube = Object.Instantiate(_cubePrefab, _parent.transform);
            cube.SetActive(false);
            var cubeView = cube.GetComponent<Rigidbody>();
            return cubeView;
        }
    }
}