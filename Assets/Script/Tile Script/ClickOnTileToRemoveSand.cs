using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    [RequireComponent(typeof(Tile))]
    public class ClickOnTileToRemoveSand : MonoBehaviour
    {
        private void Awake()
        {
            _tile = GetComponent<Tile>();
        }

        private void OnMouseDown()
        {
            if (_tile.type == TileType.sand)
            {
                _tile.type = TileType.empty;
            }
        }

        private Tile _tile;
    }
}
