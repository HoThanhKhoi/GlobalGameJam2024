using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Cat : Cat
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        Destroy(other.gameObject);
    }

    protected override void Hit()
    {
        base.Hit();
        player.stats.DecreaseHappiness(player.stats.playerStatSO.happinessDecreaseValueWhenHit);

        GameObject explosion = Instantiate(pfExplosionEffect, transform.position, Quaternion.identity);

        Destroy(explosion, 1f);

        Destroy(gameObject);
    }
}
