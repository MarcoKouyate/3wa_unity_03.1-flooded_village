using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage
{
    public enum TileType { none, empty, sand, seeds, crops, water, stone };

    public class Tile : MonoBehaviour
    {
        public TileType type;

        public int FloodedNeighbours
        {
            set => _floodedNeighbours = value;
        }

        public void UpdateState()
        {
            if (_floodedNeighbours >= 1)
            {
                CheckType();
            }
        }

        private void CheckType()
        {
            switch(type)
            {
                case TileType.seeds:
                    GrowCulture();
                    break;
                case TileType.empty:
                    Flood();
                    break;
            }
        }

        private void GrowCulture()
        {
            type = TileType.crops;
        }

        private void Flood()
        {
            type = TileType.water;
        }

        private int _floodedNeighbours;


    }
}

