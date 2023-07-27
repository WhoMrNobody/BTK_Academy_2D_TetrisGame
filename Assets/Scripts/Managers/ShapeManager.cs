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
            transform.Translate(Vector3.left);
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right);
        }

        public void MoveUp()
        {
            transform.Translate(Vector3.up);
        }

        public void MoveDown()
        {
            transform.Translate(Vector3.down);
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

