using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    //[SerializeField] private AudioClip explosionAudioClip;
    //private AudioSource audioSource;
    [SerializeField] private float speed = 4f;
    private float randomY;

    [SerializeField] private float upperBorderY;
    [SerializeField] private float lowerBorderY;

    private Rigidbody2D rb;

    protected Player player;
    private PlayerMovement playerMovement;

    private PlayerCollision playerCollision;
    private Animator enemyAnimator;
    [SerializeField] private GameObject pfExplosionEffect;
    public static event Action OnHappinessChanged;
    public void OnActionTriggered()
    {
        OnHappinessChanged?.Invoke();
    }
    void Start()
    {
        player = Player.Instance;
        playerCollision = player.GetComponent<PlayerCollision>();

        rb = GetComponent<Rigidbody2D>();
        /*
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.LogError("Explosion Audio Source is NULL");
        }
        audioSource.clip = explosionAudioClip;
        */
        /*
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("PLayer is NULL");
        }


        _enemyAnimator = GetComponent<Animator>();
        if(_enemyAnimator == null)
        {
            Debug.LogError("Enemy Animator is NULL");
        }
        */

        randomY = UnityEngine.Random.Range(upperBorderY, lowerBorderY);
        transform.position = new Vector3(20, randomY, 0);
    }

    private void Update()
    {
        HandleEvade();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);

        if (transform.position.x <= -20)
        {
            randomY = UnityEngine.Random.Range(upperBorderY, lowerBorderY);
            transform.position = new Vector3(20, randomY, 0);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.AddScore(1);
            }
            _speed = 0;
            GetComponent<Collider2D>().enabled = false;
            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            if (_player != null)
            {
                _player.Damage();
            }
            _speed = 0;
            GetComponent<Collider2D>().enabled = false;
            _enemyAnimator.SetTrigger("OnEnemyDeath");
            _audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
    }
    */

    private void HandleEvade()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log(distanceToPlayer);
        // Debug.Log(playerCollision.detectRadius);
        if (distanceToPlayer <= playerCollision.detectRadius)
        {
            OnEnterPlayerZone();
        }
        else
        {
            OnExitPlayerZone();
        }
    }

    public void OnEnterPlayerZone()
    {
        float yDistance = transform.position.y - player.transform.position.y;

        float yVelocity = yDistance > 0 ? speed : -speed;
        rb.velocity = new Vector2(rb.velocity.x, yVelocity);
    }

    public void OnExitPlayerZone()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Hit();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.AddScore(3);
            }
            speed = 0;

            Destroy(this.gameObject, 3f);
        }
    }

    public void Hit()
    {
        if (playerMovement != null)
        {
             player.AddScore(1);
        }
        speed = 0;

        GameObject explosion = Instantiate(pfExplosionEffect, transform.position, Quaternion.identity);
        
        Destroy(explosion, 1f);

        Destroy(gameObject);
    }
}