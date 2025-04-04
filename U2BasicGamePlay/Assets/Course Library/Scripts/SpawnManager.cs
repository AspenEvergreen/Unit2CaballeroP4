using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private float spawnSideX = 20;
    private float spawnSideZ = 15;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 1;
    private float spawnInterval = 0.66f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AnimalSpawnSide", startDelay, spawnInterval);
        InvokeRepeating("AnimalSpawnLeft", startDelay + 6, spawnInterval);
        InvokeRepeating("AnimalSpawnRight", startDelay + 4, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AnimalSpawnFront()
    {
       Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

       int animalIndex = Random.Range(0, animalPrefabs.Length);

       Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void AnimalSpawnLeft()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 rotationRight = new Vector3(0, 90, 0);
        Vector3 spawnLeftPos = new Vector3(spawnSideX, 0, Random.Range(0, spawnSideZ));
        Instantiate(animalPrefabs[animalIndex], spawnLeftPos, Quaternion.Euler(rotationRight));
    }
    void AnimalSpawnRight()
    {
        int animalIndex = Random.Range(0,animalPrefabs.Length);
        Vector3 rotationLeft = new Vector3(0, 270, 0);
        Vector3 spawnRightPos = new Vector3(spawnSideX, 0, Random.Range(0, spawnSideZ));
        Instantiate(animalPrefabs[animalIndex], spawnRightPos, Quaternion.Euler(rotationLeft));
    }
}