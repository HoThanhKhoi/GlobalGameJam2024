using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject jewCat;
    [SerializeField] private GameObject jewCatContainer;
    private bool _stopSpawning = false;
    [SerializeField] private GameObject[] cats; 

    private void Start()
    {
        StartCoroutine(SpawnJewCatRoutine());
        StartCoroutine(SpawnRandomCatRoutine());
    }
    IEnumerator SpawnJewCatRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (_stopSpawning == false)
        {
            GameObject newJewCat = Instantiate(jewCat);
            newJewCat.transform.parent = jewCatContainer.transform;
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator SpawnRandomCatRoutine()
    {
        yield return new WaitForSeconds(1f);
        while (_stopSpawning == false)
        {
            int randomCats = Random.Range(0, cats.Length);
            Instantiate(cats[randomCats]);

            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
