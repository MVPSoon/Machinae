using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawn1: MonoBehaviour
{
    public GameObject ennemi; // mobs à invoquer
    public Transform spawnPoint; // Point autour duquel les ennemies vont etre instanciés
    private int nbEnnemiMax=20; // nombre de mobs à invoquer par vagues
    private static int nbEnnemi=0; // nombre d'ennemis actuel
    public float spawnWait; // temps entre chaques instanciations
    public float startWait;
    public float waveWait; // temps entre chaques vagues
    public int range; // Rayon d'instanciation autour du point de spawn

    private bool _gameOver = false;

    void Start()
    {
        
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        float x;
        float z;
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < nbEnnemiMax; i++)
            {

                x = spawnPoint.position.x + UnityEngine.Random.Range(-range, range);
                z = spawnPoint.position.z + UnityEngine.Random.Range(-range, range);


                Instantiate(ennemi, new Vector3(x, spawnPoint.position.y, z), spawnPoint.rotation); // Création d'un ennemi
                nbEnnemi += 1;
                Debug.Log(nbEnnemi);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }


    }

    public void GameOver()
    {
        _gameOver = true;
    }
}