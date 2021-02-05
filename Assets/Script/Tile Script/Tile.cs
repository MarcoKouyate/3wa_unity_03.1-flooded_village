using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage
{
    public enum TileType { none, empty, sand, seeds, crops, water, stone };

    public class Tile : MonoBehaviour
    {
        public TileType type;
    }
}

