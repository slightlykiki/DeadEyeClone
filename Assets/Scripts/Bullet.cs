using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedBonus;

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
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, speedBonus));
        }
        Destroy(gameObject);
    }
}
