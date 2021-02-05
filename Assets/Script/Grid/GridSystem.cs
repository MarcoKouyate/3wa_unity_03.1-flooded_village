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

            _neighboursIndices = new int[4, 2] {
                {-1, 0},
                { 0,-1},
                { 0, 1},
                { 1, 0}
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

        private void Update()
        {
            if (!_pause && Time.time > _nextStepTime)
            {
                _nextStepTime = Time.time + _stepInterval;
                SimulateAllTiles();
                UpdateAllTiles();
            }
        }

        private void UpdateAllTiles()
        {
            foreach (Tile tile in _tiles)
            {
                tile.UpdateState();
            }
        }

        private void SimulateAllTiles()
        {
            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    SimulateTile(i, j);
                }
            }
        }

        private void SimulateTile(int x, int y)
        {
            Tile tile = _tiles[x, y].GetComponent<Tile>();
            tile.FloodedNeighbours = CountNeighboursWithType(TileType.water, x, y);
        }

        private int CountNeighboursWithType(TileType type, int x, int y)
        {
            int count = 0;

            foreach (Tile neighbour in GetNeighbours(x, y))
            {
                count += (neighbour.type == type) ? 1 : 0;
            }

            return count;
        }

        private List<Tile> GetNeighbours(int x, int y)
        {
            List<Tile> neighbours = new List<Tile>();

            for (int i = 0; i < _neighboursIndices.GetLength(0); i++)
            {
                AddNeighbourToList(neighbours, x + _neighboursIndices[i, 0], y + _neighboursIndices[i, 1]);
            }

            return neighbours;
        }

        private void AddNeighbourToList(List<Tile> neighbours, int x, int y)
        {
            if (IsNeighbourExist(x, y))
            {
                neighbours.Add(_tiles[x, y]);
            }
        }

        private bool IsNeighbourExist(int x, int y)
        {
            return !(x < 0 || x >= _columns || y < 0 || y >= _rows);
        }

        private float _nextStepTime;
        private int[,] _neighboursIndices;
        private Transform _transform;
        private Tile[,] _tiles;
    }
}
