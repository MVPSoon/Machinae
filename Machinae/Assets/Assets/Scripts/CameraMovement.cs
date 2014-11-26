using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
    public GameObject Player;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 position = new Vector3(0.0f, 10f, -15f);
        transform.position = Player.transform.position + position;
	}
}
