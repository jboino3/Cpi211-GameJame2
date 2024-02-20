using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{

    public GameObject Barrel;
    public GameObject End;
    public float speed;
     public float interval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBarrelsRepeatedly());
    }

     System.Collections.IEnumerator SpawnBarrelsRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            SpawnBarrel();
            // Wait for a random interval before spawning the next barrel
        }
    }

    void SpawnBarrel()
    {
        // Instantiate a new barrel at a random position
        GameObject newBarrel = Instantiate(Barrel, transform.position, Quaternion.identity);

        // Get the Pathfind component from the new barrel and set its end position and speed
        Pathfind barrelPathfind = newBarrel.GetComponent<Pathfind>();
        if (barrelPathfind != null)
        {
            barrelPathfind.End = End;
            barrelPathfind.speed = speed;
        }
        else
        {
            Debug.LogError("The spawned barrel does not have a Pathfind component.");
        }
    }


    // Update is called once per frame
    void Update()
    {
        Barrel.transform.position = Vector3.MoveTowards(Barrel.transform.position, End.transform.position, speed);
        if (Vector3.Distance(Barrel.transform.position, End.transform.position) < 0.1f)
        {
            // If the barrel has reached the end, destroy it
            Destroy(Barrel);
        }
    }
}
