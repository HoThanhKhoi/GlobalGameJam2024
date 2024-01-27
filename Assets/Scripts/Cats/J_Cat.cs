using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Cat : Cat
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escape Border"))
        {
            Debug.Log("Collider");
            OnActionTriggered();
        }
    }
}
