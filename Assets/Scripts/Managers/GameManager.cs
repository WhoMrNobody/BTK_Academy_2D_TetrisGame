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
        void Start()
        {
            _spawnManager= GameObject.FindObjectOfType<SpawnManager>();
            _boardManager= GameObject.FindObjectOfType<BoardManager>();
        }

        
        void Update()
        {

        }
    }

}
