using BTK_Academy_Tetris_Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTK_Academy_Tetris_Managers
{
    public class GameManager : MonoBehaviour
    {
        SpawnManager _spawnManager;
        BoardManager _boardManager;

        ShapeManager _activeShape;
        void Start()
        {
            _spawnManager= GameObject.FindObjectOfType<SpawnManager>();
            _boardManager= GameObject.FindObjectOfType<BoardManager>();

            if (_spawnManager)
            {
                if(_activeShape == null)
                {
                    _activeShape = _spawnManager.SpawnShapes();
                    _activeShape.transform.position = VectorToPrecisionNumber(_activeShape.transform.position);
                }
            }
        }

        void Update()
        {
            if(!_spawnManager || !_boardManager)
            {
                return;
            }

            if (_activeShape)
            {
                _activeShape.MoveDown();
            }
               
        }
        Vector2 VectorToPrecisionNumber(Vector2 vec) {

            return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
        }

    }

}
