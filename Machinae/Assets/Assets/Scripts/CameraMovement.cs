using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{

        //The target of the camera. The camera will always point to this object.
        public Transform _target;

        //The default distance of the camera from the target.
        public float _distance = 30.0f;

        //The speed of the camera. Control how fast the camera will rotate.
        public float _xSpeed = 1f;
        public float _ySpeed = 1f;

        //The position of the cursor on the screen. Used to rotate the camera.
        private float _x = 0.0f;
        private float _y = 0.0f;

        //Distance vector. 
        private Vector3 _distanceVector;

        /**
         * Move the camera to its initial position.
         */
        void Start()
        {
            _distanceVector = new Vector3(0.0f, 0.0f, -_distance);

            Vector2 angles = this.transform.localEulerAngles;

            _x = angles.x;
            _y = angles.y;

            this.Rotate(_x, _y);
        }

        /**
         * Rotate the camera or zoom depending on the input of the player.
         */
        void LateUpdate()
        {
            if (_target)
            {
                this.RotateControls();
            }
        }

        /**
         * Rotate the camera when the first button of the mouse is pressed.
         * 
         */
        void RotateControls()
        {
                _x += Input.GetAxis("Mouse X") * _xSpeed;
                _y += -Input.GetAxis("Mouse Y") * _ySpeed;
            
                this.Rotate(_x, _y);
        }

        /**
         * Transform the cursor mouvement in rotation and in a new position
         * for the camera.
         */
        void Rotate(float x, float y)
        {
            if (y <= 5)
                y = 5;
            //Transform angle in degree in quaternion form used by Unity for rotation.
            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);

            //The new position is the target position + the distance vector of the camera
            //rotated at the specified angle.
            Vector3 position = rotation * _distanceVector + _target.position;

            //Update the rotation and position of the camera.
            transform.rotation = rotation;
            transform.position = position;
        }

} //End class
