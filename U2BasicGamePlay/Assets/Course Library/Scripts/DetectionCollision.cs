using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectionCollision : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("weapon") && other.gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (gameObject.CompareTag("player") && other.gameObject.CompareTag("Animal"))
        {
            playerController.loselife();
            Destroy(other.gameObject);
        }
    }
}
