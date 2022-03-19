using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Controllers
{
    public class ReturnToPoolHandler
    {
        private readonly CubeMovementHandler _cubeMovementHandler;
        private readonly GameObject _parent;
        private readonly List<Rigidbody> _movingCubes;
        private readonly float _flyDistance;
        private readonly SpawnHandler _spawnHandler;

        public ReturnToPoolHandler(CubeMovementHandler cubeMovementHandler, SpawnHandler spawnHandler, GameObject parent, float flyDistance)
        {
            _cubeMovementHandler = cubeMovementHandler;
            _spawnHandler = spawnHandler;
            _movingCubes = cubeMovementHandler.MovingCubes;
            _parent = parent;
            _flyDistance = flyDistance;
        }

        public void DistanceControl()
        {
            for (var index = 0; index < _movingCubes.Count; index++)
            {
                var cube = _movingCubes[index];
                var distance = (cube.transform.position - _parent.transform.position).magnitude;
                if (distance >= _flyDistance)
                {
                    _spawnHandler.ReturnToPool(cube);
                    _movingCubes.Remove(cube);
                }
            }
        }        
    }
}