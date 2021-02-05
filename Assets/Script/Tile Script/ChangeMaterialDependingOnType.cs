using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    [RequireComponent(typeof(Tile))]
    [RequireComponent(typeof(MeshRenderer))]
    public class ChangeMaterialDependingOnType : MonoBehaviour
    {
        [SerializeField] private TileTypeData[] types;

        private void Awake()
        {
            _tile = GetComponent<Tile>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _currentType = TileType.none;
            UpdateTileType();
        }

        private void Update()
        {
            UpdateTileType();
        }

        private void UpdateTileType()
        {
            if (_currentType == _tile.type)
            {
                return;
            }

            foreach (TileTypeData tileData in types)
            {
                if(tileData.type == _tile.type)
                {
                    ChangeTypeTo(tileData);
                }
            }
        }

        private void ChangeTypeTo(TileTypeData tileData)
        {
            _currentType = tileData.type;
            _meshRenderer.material = tileData.material;
        }

        private TileType _currentType;
        private Tile _tile;
        private MeshRenderer _meshRenderer;
    }
}
