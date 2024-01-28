using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    //References
    protected Player player;
    protected Hitler hitler;
    private PlayerCollision playerCollision;
    private HitlerCollision hitlerCollision;

    //Component
    private Rigidbody2D rb;

    //Spawn Handling
    [SerializeField] private float upperBorderY;
    [SerializeField] private float lowerBorderY;

    [SerializeField] private float xPosDestroyBorder = -20f;
    [SerializeField] private float xPosSpawn = 20f;
    private float randomY;

    //Movement
    [SerializeField] private float speed = 4f;

    //Explosion
    [SerializeField] protected GameObject pfExplosionEffect;

    void Start()
    {
        player = Player.Instance;
        playerCollision = player.GetComponent<PlayerCollision>();

        hitler = Hitler.Instance;
        hitlerCollision = hitler.GetComponent<HitlerCollision>();

        rb = GetComponent<Rigidbody2D>();

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

        if (transform.position.x <= xPosDestroyBorder)
        {
            Destroy(gameObject);
        }
    }

    #region Evade Player
    private void HandleEvade()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToHitler = Vector2.Distance(transform.position, hitler.transform.position);

        if (distanceToPlayer > playerCollision.detectRadius && distanceToHitler > hitlerCollision.detectRadius)
        {
            OnExitEntityZone();
        }
        else
        {
            if (distanceToPlayer <= playerCollision.detectRadius)
            {
                OnEnterEntityZone(player.transform);
            }
            if (distanceToHitler <= hitlerCollision.detectRadius)
            {
                OnEnterEntityZone(hitler.transform);
            }
        }
    }

    public void OnEnterEntityZone(Transform entity)
    {
        float yDistance = transform.position.y - entity.transform.position.y;

        float yVelocity = yDistance > 0 ? speed : -speed;
        rb.velocity = new Vector2(rb.velocity.x, yVelocity);
    }

    public void OnExitEntityZone()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
    #endregion

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Hit();
        }
    }

    protected virtual void Hit()
    {
        speed = 0;

    }
}