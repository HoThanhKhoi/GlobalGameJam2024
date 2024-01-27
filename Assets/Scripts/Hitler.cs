using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitler : MonoBehaviour
{
    public static Hitler Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
