using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public int score;

    public AudioSource audioSource;
    public AudioClip[] clips;

    public bool gameOver;

    public bool gameStart;

    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clips[(int)AudioNames.BallThrownInAir]);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
        }
        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
        }
        
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
