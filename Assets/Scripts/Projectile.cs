using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float bulletSpeed;
    public Rigidbody2D bulletInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (bulletInstance == null)
            {
                bulletInstance = Instantiate(bullet, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
            }
            bulletInstance.gameObject.SetActive(true);
            bulletInstance.transform.position = transform.position + new Vector3(0f, 2f, 0f);
                bulletInstance.velocity = new Vector2(0f, bulletSpeed);
        }
    }
}
