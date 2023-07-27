using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BTK_Academy_Tetris_Managers
{
    public class BoardManager : MonoBehaviour
    {
        public static BoardManager Instance;

        [SerializeField] private Transform _tilePrefab;

        public int yukseklik = 22;
        public int genislik = 10;
        void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            MakeEmptyBoxes();
        }

        bool IsShapeInBoard(int x, int y)
        {
            return (x>=0 && x < genislik && y>=0);
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
            }

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

        Vector2 VectorToPrecisionNumber(Vector2 vec)
        {

            return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
        }


    }
}

