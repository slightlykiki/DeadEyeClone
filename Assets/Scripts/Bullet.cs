using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBonus;
    public float coinModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Coin>())
        {
            gameManager.instance.score += 5;
            float coinVelocity = (collision.transform.position.x - transform.position.x) * coinModifier;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(coinVelocity, speedBonus));
        }
        gameObject.SetActive(false);
    }
}
