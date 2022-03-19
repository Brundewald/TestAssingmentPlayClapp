using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Controllers
{
    public class CubeMovementHandler
    {
        private readonly ParseInput _parseInput;
        private readonly List<Rigidbody> _movingCubes;
        
        public List<Rigidbody> MovingCubes => _movingCubes;

        public CubeMovementHandler(ParseInput parseInput)
        {
            _parseInput = parseInput;
            _movingCubes = new List<Rigidbody>();
        }
        
        public void MoveCube(Rigidbody cube)
        {
            if(cube is null) return;
            var cubeSpeed = _parseInput.ParsedAcceleration();
            cube.AddForce(Vector3.left*cubeSpeed, ForceMode.Impulse);
            _movingCubes.Add(cube);
        }
    }
}