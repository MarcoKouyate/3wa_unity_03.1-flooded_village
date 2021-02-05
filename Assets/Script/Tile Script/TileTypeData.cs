using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    [CreateAssetMenu(menuName="Custom/Tile Type Data")]
    public class TileTypeData : ScriptableObject
    {
        public TileType type;
        public Material material;
    }
}
