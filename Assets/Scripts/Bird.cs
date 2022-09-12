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
    public Sprite[] wings;
    public float AnimT = 0;

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
                gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.BirdSpawn]);
            }
            if (isDead == true)
            {
                transform.Translate(new Vector2(0, birdSpeedY * Time.deltaTime));
                AnimT++;
                if (AnimT >= 0)
                {
                    transform.localScale = new Vector3(3.2f, 3.2f, 1);
                }
                if (AnimT >= 0.1f * 60)
                {
                    transform.localScale = new Vector3(-3.2f, 3.2f, 1);
                }
                if (AnimT >= 0.2f * 60)
                {
                    AnimT = 0;
                }
            }
            else
            {
                transform.Translate(new Vector2(birdSpeedX * Time.deltaTime, 0));
                AnimT++;
                if (AnimT >= 0)
                {
                    GetComponent<SpriteRenderer>().sprite = wings[0];
                }
                if (AnimT >= 0.1f * 60)
                {
                    GetComponent<SpriteRenderer>().sprite = wings[1];
                }
                if (AnimT >= 0.2f * 60)
                {
                    GetComponent<SpriteRenderer>().sprite = wings[2];
                }
                if (AnimT >= 0.3f * 60)
                {
                    AnimT = 0;
                }
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
            gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.BirdDie]);
            isDead = true;
            gameManager.instance.score += 1000;
            AnimT = 0;
            GetComponent<SpriteRenderer>().sprite = wings[3];
        }
    }

}
