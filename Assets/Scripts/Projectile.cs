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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && gameManager.instance.gameOver == false)
        {
            if (coinSpawned)
            {
                if (bulletInstance == null)
                {
                    bulletInstance = Instantiate(bullet, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                }
                bulletInstance.gameObject.SetActive(true);
                bulletInstance.transform.position = transform.position + new Vector3(0f, 2f, 0f);
                bulletInstance.velocity = new Vector2(0f, bulletSpeed);
                gameManager.instance.audioSource.PlayOneShot(gameManager.instance.clips[(int)AudioNames.ShootBullet]);
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
