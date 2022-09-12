using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float birdSpeedX;
    public float birdSpeedY;
    float targetTime;
    float actualTime;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        birdSpawner();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.instance.gameStart == true)
        {
            actualTime += Time.deltaTime;
            if (actualTime >= targetTime)
            {
                isDead = false;
                transform.position = new Vector2(12, 3.4f);
                actualTime = 0;
                birdSpawner();
            }
            if (isDead == true)
            {
                transform.Translate(new Vector2(0, birdSpeedY * Time.deltaTime));
            }
            else
            {
                transform.Translate(new Vector2(birdSpeedX * Time.deltaTime, 0));
            }
        }
    }

    void birdSpawner()
    {
        targetTime = Random.Range(15, 30);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead == false)
        {
            isDead = true;
            gameManager.instance.score += 1000;
        }
    }

}
