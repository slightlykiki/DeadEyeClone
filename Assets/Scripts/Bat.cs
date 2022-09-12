using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        batSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        batSpawner();
        gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.BatDie]);
        gameManager.instance.score += 50;
    }

    void batSpawner()
    {
        float xPosition = Random.Range(-9.5f, 9.5f);
        transform.position = new Vector2(xPosition, 3.4f);
    }
}
