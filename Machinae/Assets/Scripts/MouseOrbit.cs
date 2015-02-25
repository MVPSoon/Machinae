using UnityEngine;
using System.Collections;

// Goal: make the camera follow an orbit over a target
public class MouseOrbit : MonoBehaviour {

    public Transform _target;
    public float distance = 10.0F; //Distance between camera and target

    public float xSpeed = 250;
    public float ySpeed = 120;

    public float y_minLimit = 0.0F;
    public float y_maxLimit = 20.0F;

    private float x = 0.0F, y = 0.0F;
    private float deadzone = 0.25F; //Minimum position value that the joytstick must have

    internal static bool enableMovement = true;

	void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        //Make the rigidbody not change its rotation
        if(rigidbody)
            rigidbody.freezeRotation = true;
	}
	
	void LateUpdate () {
        if (enableMovement)
        {
            if (_target)
            {
                Vector2 stickInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                /*JOYSTICK SECTION*/
                /*We test the magnitude of the stick to correct the drift which could occure and make the camera move on her own even if we don't press any direction*/
                if (stickInput.magnitude < deadzone)
                    stickInput = Vector2.zero;
                else
                    stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
                /*END JOYSTICK SECTION*/

                x += stickInput.x * xSpeed * 0.02F;
                y -= stickInput.y * ySpeed * 0.02F;

                y = ClampAngle(y, y_minLimit, y_maxLimit);

                Quaternion rotation = Quaternion.Euler(y, x, 0);
                Vector3 position = rotation * new Vector3(0.0F, 0.0F, -distance) + _target.position;

                transform.rotation = rotation;
                transform.position = position;
            }
        }
	}

    // Force an angle to be between -360° and 360°
    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
