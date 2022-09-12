using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public bool direct = true;
    public float animT = 0f;
    public Sprite[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direct == false)
        {
            transform.localScale = new Vector3(-9, 9, 1);
        }
        else
        {
            transform.localScale = new Vector3(9, 9, 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed*Time.deltaTime, 0);
            direct = false;
            animT++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
            direct = true;
            animT++;
        }

        if (animT <= 0.1 * 60)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else 
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        if (animT > 0.2 * 60)
        {
            animT = 0;
        }

    }
}
