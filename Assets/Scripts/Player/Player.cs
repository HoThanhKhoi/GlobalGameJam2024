using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}

    private int _score;

    private SpawnManager _spawnManager;

    //private UIManager _uiManager;
    // Start is called before the first frame update
    private void Awake() {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start() {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if( _spawnManager == null)
        {
            Debug.LogError("Spawner is NULL");
        }
        /*
        if( _uiManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
        */
    }
    public void AddScore(int points)
    {
        _score += points;
        //_uiManager.UpdateScore(_score);
    }
}
