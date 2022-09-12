using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed;
    public Rigidbody2D bulletInstance;
    public bool coinSpawned = false;
    public Rigidbody2D coin;
    public Sprite[] shootSpr;
    public float animT = 0;
    private Movement parent;
    public float offset = 1;

 

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Movement>();

    }

    private void FixedUpdate()
    {
        animT--;
        if (animT >= 0)
        {
            GetComponent<SpriteRenderer>().sprite = shootSpr[2];
        }
        if (animT >= 0.1 * 60)
        {
            GetComponent<SpriteRenderer>().sprite = shootSpr[1];
        }
        if (animT < 0)
        {
            GetComponent<SpriteRenderer>().sprite = shootSpr[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.direct == true)
        {
            offset = 1;
        } 
        else
        {
            offset = -1;
        }

        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && gameManager.instance.gameOver == false)
        {
            if (coinSpawned)
            {
                if (bulletInstance == null)
                {
                    bulletInstance = Instantiate(bullet, transform.position + new Vector3(0.8f * offset, 1f, 0f), Quaternion.identity);
                }
                bulletInstance.gameObject.SetActive(true);
                bulletInstance.transform.position = transform.position + new Vector3(0.8f * offset, 1f, 0f);
                bulletInstance.velocity = new Vector2(0f, bulletSpeed);
                gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.ShootBullet]);
                animT = 0.2f * 60;
            } else
            {
                var firstCoin = Instantiate(coin, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                firstCoin.velocity = new Vector2(0f, 5f);
                coinSpawned = true;
                gameManager.instance.gameStart = true;
                gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.BallThrownInAir]);
            }
        }
    }
}
