using Assets.Code.Controllers;
using UnityEngine;

namespace Assets.Code.View
{
    public class RootView : MonoBehaviour
    {
        [SerializeField] private HudView _hudView;
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private GameObject _parentObject;
        [SerializeField] private float _flyDistance;
        [SerializeField] private int _poolSize;
        private GameHandler _gameHandler;

        private void Start()
        {
            _gameHandler = new GameHandler(_hudView, _cubePrefab, _parentObject, _poolSize, _flyDistance);
            _gameHandler.Intialization();
        }

    
        private void Update()
        {
            _gameHandler.Update(Time.deltaTime);
        }
    }   
}
