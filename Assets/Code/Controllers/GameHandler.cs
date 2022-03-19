using System.Collections.Generic;
using System.Timers;
using Assets.Code.View;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Code.Controllers
{
    public class GameHandler
    {
        private readonly GameObject _parent;
        private readonly TMP_InputField _accelerationInput;
        private readonly TMP_InputField _spawnIntervalInput;
        private readonly GameObject _cubePrefab;
        private readonly int _poolSize;
        private readonly float _flyDistance;
        private ParseInput _parseHandler;
        private SpawnHandler _spawnHandler;
        private CubeMovementHandler _cubeMovementHandler;
        private ReturnToPoolHandler _returnToPoolHandler;
        private float _spawnInterval = 0;
        private float _timer;

        public GameHandler(HudView hudView, GameObject cubePrefab, GameObject parentObject, int poolSize,
            float flyDistance)
        {
            _accelerationInput = hudView.AccelerationInput;
            _spawnIntervalInput = hudView.SpawnIntervalInput;
            _cubePrefab = cubePrefab;
            _parent = parentObject;
            _poolSize = poolSize;
            _flyDistance = flyDistance;
        }

        public void Intialization()
        {
            _parseHandler = new ParseInput(_accelerationInput, _spawnIntervalInput);
            _spawnHandler = new SpawnHandler(_cubePrefab, _parent, _poolSize);
            _cubeMovementHandler = new CubeMovementHandler(_parseHandler);
            _returnToPoolHandler = new ReturnToPoolHandler(_cubeMovementHandler, _spawnHandler, _parent, _flyDistance);
        }

        public void Update(float fixedDeltaTime)
        {
            SpawnRoutine(fixedDeltaTime);
        }

        private void SpawnRoutine(float fixedDeltaTime)
        {
            _spawnInterval = _parseHandler.ParsedSpawnInterval();
            
            if (_spawnInterval > 0)
            {
                _timer += fixedDeltaTime;
                if (_spawnInterval < _timer)
                {
                    var spawnCubeRigidbody = _spawnHandler.GetFromPool();
                    _cubeMovementHandler.MoveCube(spawnCubeRigidbody);
                    _timer = 0;
                }

                _returnToPoolHandler.DistanceControl();
            }}
    }
}