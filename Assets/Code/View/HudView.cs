using TMPro;
using UnityEngine;

namespace Assets.Code.View
{
    public class HudView: MonoBehaviour
    {
        [SerializeField] private TMP_InputField _accelerationInput;
        [SerializeField] private TMP_InputField _spawnIntervalInput;

        public TMP_InputField AccelerationInput => _accelerationInput;
        public TMP_InputField SpawnIntervalInput => _spawnIntervalInput;
    }
}