using System.Collections;
using UnityEngine;

public class BSpawner : MonoBehaviour
{
    public GameObject BPrefab; // Assign the barrel prefab in Unity 

    public float initialDelay = 2f;
    public float minDelay = 1.1f;
    public float maxDelay = 2.5f;
    public float delayReductionRate = 0.1f;
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public float[] zPositions = { -0.89f, 2.19f, 4.74f };
    private float lastZPosition = 0f; // Variable to store the last Z position

    private void Start()
    {
        StartCoroutine(SpawnBRandomly());
    }

    IEnumerator SpawnBRandomly()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            SpawnB();

            float randomDelay = Random.Range(minDelay, maxDelay);
            maxDelay -= delayReductionRate;
            maxDelay = Mathf.Max(maxDelay, minDelay);

            yield return new WaitForSeconds(randomDelay);
        }
    }

    public void SpawnB()
    {
        // Randomly choose one of the Z positions ensuring it's not the same as the last spawn
        float randomZ = lastZPosition;
        while (randomZ == lastZPosition)
        {
            randomZ = zPositions[Random.Range(0, zPositions.Length)];
        }
        lastZPosition = randomZ; // Update the last position

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        Vector3 spawnPosition = new Vector3(1.5f, 6.55f, randomZ);

        GameObject newB = Instantiate(BPrefab, spawnPosition, rotation);
        newB.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}