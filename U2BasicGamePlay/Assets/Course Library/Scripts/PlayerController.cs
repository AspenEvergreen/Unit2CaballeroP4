using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // for movement
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;

    // for boundaries
    public float xRange = 20;
    public float zRangeTop = 15;
    public float zRangeBottom = 0;

    //projectile
    public GameObject projectilePrefab;

    //lives
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
        // basic movement

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // keep the player in

        // x axis
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // y axis
        if(transform.position.z > zRangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeTop);
        }

        if (transform.position.z < zRangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRangeBottom);
        }

        // launch projectiles from player
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    // respawn
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
