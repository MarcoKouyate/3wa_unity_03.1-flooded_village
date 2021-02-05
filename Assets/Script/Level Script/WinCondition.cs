using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private GridSystem _grid;
        [SerializeField] private GameState _gameState;

        private void Update()
        {
            if (!_gameState.pause && _grid.CountTileOfType(TileType.seeds) <= 0)
            {
                Win();
            }
        }

        private void Win()
        {
            Debug.Log("Win!");
        }
        
    }
}
