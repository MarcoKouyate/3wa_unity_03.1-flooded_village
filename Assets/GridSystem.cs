using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloodedVillage {
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private float _stepInterval;
        [SerializeField] private bool _pause;

        public bool Pause
        {
            get => _pause;
            set => _pause = value;
        }

        private void Awake()
        {
            Init();
            CreateTiles();
        }


        private void Init()
        {
            _nextStepTime = Time.time;

            _tiles = new Tile[_columns, _rows];
            _transform = transform;

            _neighboursIndices = new int[8, 2] {
                {-1,-1},
                {-1, 0},
                {-1, 1},

                { 0,-1},
                { 0, 1},

                { 1,-1},
                { 1, 0},
                { 1, 1}
            };
        }

        private void CreateTiles()
        {
            Vector2 tileScale = new Vector2(_transform.localScale.x / _columns, _transform.localScale.y / _rows);
            Vector2 offset = new Vector2(_transform.position.x - _transform.localScale.x / 2 + tileScale.x / 2, _transform.position.y + _transform.localScale.y / 2 - tileScale.y / 2);


            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {

                    GameObject tile = Instantiate(_tilePrefab, _transform);
                    tile.transform.localScale = tileScale / (Vector2)_transform.localScale;
                    tile.transform.position = _transform.position + (Vector3)offset + Vector3.right * (tileScale.x * i) + Vector3.down * (tileScale.y * j);
                    _tiles[i, j] = tile.GetComponent<Tile>();
                }
            }
        }


        void OnDrawGizmos()
        {
            // Draw a yellow cube at the transform position
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, transform.localScale);
        }

        private float _nextStepTime;
        private int[,] _neighboursIndices;
        private Transform _transform;
        private Tile[,] _tiles;
    }
}
