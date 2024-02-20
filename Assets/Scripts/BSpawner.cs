using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine;
using UnityEngine.UIElements;

public class BSpawner : MonoBehaviour
{
    public GameObject BPrefab; // Assign the barrel prefab in Unity 

    // Variables to control spawning behavior
    public float initialDelay = 2f; // Initial delay before spawning begins
    public float minDelay = 0.5f; // Minimum delay between spawns
    public float maxDelay = 5f; // Maximum delay between spawns
    public float delayReductionRate = 0.1f; // Rate at which delay decreases
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public float[] zPositions = { -0.89f, 2.19f, 4.74f }; // Array of predefined Z positions

    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnBRandomly());
    }

    IEnumerator SpawnBRandomly()
    {
        // Initial delay before spawning begins
        yield return new WaitForSeconds(initialDelay);

        // Loop indefinitely to spawn balls
        while (true)
        {
            // Spawn a ball
            SpawnB();

            // Calculate a new random delay within the specified range
            float randomDelay = Random.Range(minDelay, maxDelay);

            // Reduce the maximum delay over time
            maxDelay -= delayReductionRate;

            // Ensure the delay doesn't go below the minimum
            maxDelay = Mathf.Max(maxDelay, minDelay);

            // Wait for the next spawn according to the random delay
            yield return new WaitForSeconds(randomDelay);
        }
    }


    public void SpawnB()
    {
        // Randomly choose one of three Z positions
        float randomZ = zPositions[Random.Range(0, zPositions.Length)];

        //so its rotated the right way
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, zRotation);

        // Create a Vector3 with the  x, y, and z coords
        Vector3 spawnPosition = new Vector3(1.5f, 6.55f, randomZ);

        //New barrel at spawner position
        GameObject newB = Instantiate(BPrefab, spawnPosition, rotation);

        //set barrel scale
        newB.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);


        // You can add velocity or other properties to the new ball here
    }
}

