using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private AudioClip explosionAudioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.LogError("Asteroid Audio Source is NULL");
        }
        audioSource.clip = explosionAudioClip;
        audioSource.Play();
        Destroy(this.gameObject, 3f);
    }
}
