using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_Tetris_Managers
{
    public class ShapeManager : MonoBehaviour
    {
        [SerializeField] bool _isCanRotate = true;

        public void MoveLeft()
        {
            transform.Translate(Vector3.left, Space.World);
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right, Space.World);
        }

        public void MoveUp()
        {
            transform.Translate(Vector3.up, Space.World);
        }

        public void MoveDown()
        {
            transform.Translate(Vector3.down, Space.World);
        }

        public void RotateLeft()
        {   
            if(_isCanRotate)
            {
                transform.Rotate(new Vector3(0, 0, 90f));
            }

        }

        public void RotateRight()
        {
            if(_isCanRotate)
            {
                transform.Rotate(new Vector3(0, 0, -90f));
            }
        }



    }
}

