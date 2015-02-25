using UnityEngine;
using System.Collections;

public class Spawn3 : MonoBehaviour {

    public GameObject mobs;
    public float spawnTime = 2f;
    public Transform spawnPoint;
    public int range;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {

        float x;
        float z;

        x = spawnPoint.position.x + Random.Range(-range, range);
        z = spawnPoint.position.z + Random.Range(-range, range);


        Instantiate(mobs, new Vector3(x,spawnPoint.position.y,z), spawnPoint.rotation);
    }


    // Update is called once per frame
    void Update()
    {

    }
	
}