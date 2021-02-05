using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    public class Pause : MonoBehaviour
    {

        [SerializeField] private bool pauseOnAwake;
        [SerializeField] private GameState _gameState;
        private void Awake()
        {
            _gameState.pause = pauseOnAwake;
        }

        private void Update()
        {
            if(Input.GetButtonDown("Pause"))
            {
                _gameState.pause = !_gameState.pause;
            }
        }
    }
}
