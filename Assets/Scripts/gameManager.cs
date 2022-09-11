using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public int score;

    public AudioSource audioSource;
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips[(int)AudioNames.BallThrownInAir]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum AudioNames
{
    BallThrownInAir,
    ShootBullet,
    BallBounceWall,
    BounceOffWheel,
    BallFallToGround,
    BulletHitsCoin,
    BirdSpawn,
    BirdDie,
    BatDie
}
