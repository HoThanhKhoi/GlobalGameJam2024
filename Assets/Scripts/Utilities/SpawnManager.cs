using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject jewCat;
    [SerializeField] private GameObject jewCatContainer;
    private bool _stopSpawning = false;
    [SerializeField] private GameObject[] cats;

    private float initialJewCatSpawnRate = 5f;
    private float initialRandomCatSpawnRate = 3f;
    private float spawnRateDecreaseInterval = 10f;
    private float spawnRateDecreaseAmount = 0.1f;

    private void Start()
    {
        StartCoroutine(SpawnJewCatRoutine());
        StartCoroutine(SpawnRandomCatRoutine());
        StartCoroutine(DecreaseSpawnRate());
    }

    IEnumerator SpawnJewCatRoutine()
    {
        yield return new WaitForSeconds(2f);
        while (_stopSpawning == false)
        {
            GameObject newJewCat = Instantiate(jewCat);
            newJewCat.transform.parent = jewCatContainer.transform;
            yield return new WaitForSeconds(initialJewCatSpawnRate);
        }
    }

    IEnumerator SpawnRandomCatRoutine()
    {
        yield return new WaitForSeconds(1f);
        while (_stopSpawning == false)
        {
            int randomCats = Random.Range(0, cats.Length);
            Instantiate(cats[randomCats]);

            yield return new WaitForSeconds(initialRandomCatSpawnRate);
        }
    }

    IEnumerator DecreaseSpawnRate()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnRateDecreaseInterval);

            // Decrease spawn rates
            initialJewCatSpawnRate -= spawnRateDecreaseAmount;
            initialRandomCatSpawnRate -= spawnRateDecreaseAmount;

            // Ensure spawn rates don't go below a minimum value
            initialJewCatSpawnRate = Mathf.Max(initialJewCatSpawnRate, 0.1f);
            initialRandomCatSpawnRate = Mathf.Max(initialRandomCatSpawnRate, 0.1f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
