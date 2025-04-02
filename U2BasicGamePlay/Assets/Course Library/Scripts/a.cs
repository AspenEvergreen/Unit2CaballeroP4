using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public int lives = 3;
    private Vector3 respawnPosition = Vector3.zero;
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Respawn()
    {
        transform.position = respawnPosition;
    }

    private void GameOver()
    {
        Debug.Log("Game Over !");
        spawnManager.IsSpawning = false;
    }

    public void loselife()
    {
        lives--;
        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            GameOver();
        }
    }
}
