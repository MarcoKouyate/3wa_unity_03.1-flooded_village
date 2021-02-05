using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    [CreateAssetMenu(menuName = "Custom/Game State")]
    public class GameState : ScriptableObject
    {
        public bool pause;
    }
}
