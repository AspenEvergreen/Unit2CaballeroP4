using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerSide : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnSideX = 20;
    private float spawnSideZ = 15;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("sideSpawn", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sideSpawn()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 rotationRight = new Vector3(0, 90, 0);

        Vector3 rotationLeft = new Vector3(0, 270, 0);

        Vector3 spawnRight = new Vector3(spawnSideX, 0, Random.Range(0, spawnSideZ));

        Vector3 spawnLeft = new Vector3(-spawnSideX, 0, Random.Range(0, spawnSideZ));

        Instantiate(animalPrefabs[animalIndex], spawnRight, Quaternion.Euler(rotationLeft));

        Instantiate(animalPrefabs[animalIndex], spawnLeft, Quaternion.Euler(rotationRight));
    }
}
