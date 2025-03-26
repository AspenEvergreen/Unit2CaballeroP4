using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    
    private float SPZ = 20;
    private float SPX = 20;

    private float startDelay = 1;
    private float spawnInterval = 0.66f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimalTop()
    {
        // randomly spawn animals

        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, SPZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(-SPX, 0, Random.Range(0, spawnRangeZ));

        Quaternion rotationLeft = Quaternion.Euler(0, 90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, rotationLeft);
    }

    void SpawnRandpmAnimalRight()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(-SPX, 0, Random.Range(0, spawnRangeZ));

        Quaternion rotationRight = Quaternion.Euler(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPos, rotationRight);
    }
}
    
