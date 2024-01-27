using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Cat : Cat
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Escape Border"))
        {
            Debug.Log("Escaped");
            player.stats.DecreaseHappiness(player.stats.playerStatSO.happinessDecreaseValueWhenEscape);
        }
    }

    protected override void Hit()
    {
        base.Hit();
        AudioManager.Instance.Play("CatScreamAudio");
    }
}