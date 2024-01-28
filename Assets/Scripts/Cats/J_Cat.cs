using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Cat : Cat
{
    //Exp
    [SerializeField] private int expPerKill;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Escape Border"))
        {
            Debug.Log("Escaped");
            player.stats.DecreaseHappiness(player.stats.playerStatSO.happinessDecreaseValueWhenEscape);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }

    protected override void Hit()
    {
        base.Hit();
        

        GameObject explosion = Instantiate(pfExplosionEffect, transform.position, Quaternion.identity);

        Destroy(explosion, 1f);

        Destroy(gameObject);

        Debug.Log(expPerKill);

        LevelManager.Instance.AddExp(expPerKill);
    }
}