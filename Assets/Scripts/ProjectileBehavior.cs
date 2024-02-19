using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        // Destroy the projectile after 2 seconds
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        // Move the projectile in the positive x direction and at a 45-degree angle upwards
        Vector3 moveDirection = new Vector3(1, 0.5f, 0).normalized; // Adjust this vector if needed
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject is not the player
        if (!other.CompareTag("Player")) // Ensure your player GameObject is tagged "Player"
        {
            Debug.Log("Collision! (GENERIC)");

            // Check if the collided object is a "Barrel" or a clone of it
            if (other.gameObject.name.StartsWith("Barrel"))
            {
                Debug.Log("Collision! (BARREL)");
                Destroy(other.gameObject); // Destroy the barrel
            }

            Destroy(gameObject); // Destroy the projectile itself
        }
    }

}
