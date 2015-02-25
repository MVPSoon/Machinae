using UnityEngine;
using System.Collections;

public class Spawn3 : MonoBehaviour {

    public GameObject mobs; // Ennemi à invoquer 
    public float spawnTime = 2f; // Temps entre chaque instance
    public Transform spawnPoint; // Point autour duquel les ennemies vont etre instanciés
    public int range; // Rayon d'instance autour du point de spawn


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime); // répétition du spawn d'ennemis
    }

    void Spawn()
    {

        float x;
        float z;

        x = spawnPoint.position.x + Random.Range(-range, range);
        z = spawnPoint.position.z + Random.Range(-range, range);


        Instantiate(mobs, new Vector3(x,spawnPoint.position.y,z), spawnPoint.rotation); // Création d'un ennemi
    }


    // Update is called once per frame
    void Update()
    {

    }
	
}