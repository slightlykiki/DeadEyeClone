using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            gameManager.instance.score += 500;
        }
        if (collision.gameObject.CompareTag("ceiling"))
        {
            gameManager.instance.score += 100;
        }
        if(collision.gameObject.CompareTag("topWheel"))
        {
            gameManager.instance.score += 2000;
        }
        if (collision.gameObject.CompareTag("bottomWheel"))
        {
            gameManager.instance.score += 4000;
        }
    }
}
