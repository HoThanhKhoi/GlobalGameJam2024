using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_CatDieSound : MonoBehaviour
{
    [SerializeField] private AudioClip catScreamAudioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.LogError("Audio Source is NULL");
        }
        audioSource.clip = catScreamAudioClip;
        audioSource.Play();
        Destroy(this.gameObject, 3f);
    }
}
