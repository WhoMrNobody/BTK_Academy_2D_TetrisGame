using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BTK_Academy_Tetris_Managers
{
    public class BoardManager : MonoBehaviour
    {

        [SerializeField] private Transform _tilePrefab;

        public int yukseklik = 19;
        public int genislik = 10;

        Transform[,] _grid;

        private void Awake()
        {
            _grid = new Transform[genislik, yukseklik];
        }
        private void Start()
        {
            MakeEmptyBoxes();
        }

        bool IsShapeInBoard(int x, int y)
        {
            return (x >= 0 && x < genislik && y >= 0);
        }

        public bool InRightPos(ShapeManager shape)
        {
            foreach (Transform child in shape.transform)
            {
                Vector2 pos = VectorToPrecisionNumber(child.position);
               
                if (!IsShapeInBoard((int)pos.x, (int)pos.y))
                {
                    return false;
                }

                if(pos.y < yukseklik)
                {
                    if (IsGridFull((int)pos.x, (int)pos.y, shape))
                    {
                        return false;
                    }
                }
                
            }

            Debug.Log("trueee");
            return true;
        }
        void MakeEmptyBoxes()
        {   
            if(_tilePrefab != null)
            {
                for (int y = 0; y < yukseklik; y++)
                {
                    for (int x = 0; x < genislik; x++)
                    {
                        Transform tile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                        tile.name = "x " + x.ToString() + "," + "y " + y.ToString();
                        tile.parent = this.transform;
                    }
                }
            }
            else
            {
                Debug.Log("_tilePrefab gameObject reference is empty");
            }

        }

        public void MakeChildShapeInGrid(ShapeManager shape)
        {
            if (shape == null) return;

            foreach (Transform child in shape.transform)
            {
                Vector2 pos = VectorToPrecisionNumber(child.position);
                _grid[(int)pos.x, (int)pos.y] = child;
            }
        }

        bool IsGridFull(int x, int y, ShapeManager shape)
        {
            return (_grid[x, y] != null && _grid[x, y].parent != shape.transform);
        }

        Vector2 VectorToPrecisionNumber(Vector2 vec)
        {

            return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
        }


    }
}

