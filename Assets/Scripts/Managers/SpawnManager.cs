using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_Tetris_Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] ShapeManager[] _shapes;
        void Start()
        {

        }

        public ShapeManager SpawnShapes()
        {
            int randomValue = Random.Range(0, _shapes.Length);

            ShapeManager shape = Instantiate(_shapes[randomValue], transform.position, Quaternion.identity) as ShapeManager;

            if(shape != null )
            {
                return shape;
            }
            else
            {
                Debug.Log("Shapes list is empty");
                return null;
            }
            
        }
    }
}

