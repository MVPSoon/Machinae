using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed = 10;
    public float rotateSpeed = 60;
    public GameObject cam;

    private float deadzone = 0.25F;
    
    void Update()
    {
        Transform camTransform = cam.transform;

        Vector2 stickInput2 = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        /*JOYSTICK SECTION*/
        if (stickInput2.magnitude < deadzone)
            stickInput2 = Vector2.zero;
        else
            stickInput2 = stickInput2.normalized * ((stickInput2.magnitude - deadzone) / (1 - deadzone));
        /*END JOYSTICK SECTION*/

        float mvtV = stickInput2.x * moveSpeed * Time.deltaTime;
        transform.Translate(0, 0, mvtV);
        transform.rotation = cam.transform.rotation;
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
    }

}
