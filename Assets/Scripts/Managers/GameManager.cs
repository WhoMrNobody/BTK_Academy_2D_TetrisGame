using BTK_Academy_Tetris_Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTK_Academy_Tetris_Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Counter")]
        [Range(0.01f, 1f)]
        [SerializeField] float _spawnRate=0.5f;

        SpawnManager _spawnManager;
        BoardManager _boardManager;
        ShapeManager _activeShape;

        float _spawnCounter;
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

            if (Time.time > _spawnCounter)
            {
                _spawnCounter = Time.time + _spawnRate;

                if (_activeShape)
                {
                    _activeShape.MoveDown();

                    if (!_boardManager.InRightPos(_activeShape))
                    {
                        _activeShape.MoveUp();
                        _boardManager.MakeChildShapeInGrid(_activeShape);

                        if (_spawnManager)
                        {
                            _activeShape = _spawnManager.SpawnShapes();
                        }
                    }
                }
            }

           
               
        }
        Vector2 VectorToPrecisionNumber(Vector2 vec) {

            return new Vector2(Mathf.Round(vec.x), Mathf.Round(vec.y));
        }

    }

}
