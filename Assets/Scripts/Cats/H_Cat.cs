using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Cat : Cat
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        
    }

    protected override void Hit()
    {
        base.Hit();
        AudioManager.Instance.Play("CatScreamAudio");
        player.stats.DecreaseHappiness(player.stats.playerStatSO.happinessDecreaseValueWhenHit);
    }


}