using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Cat : Cat
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Bullet"))
        {
            player.stats.DecreaseHappiness(player.stats.playerStatSO.happinessDecreaseValueWhenHit);
        }
    }
}
