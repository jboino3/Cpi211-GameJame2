using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign in inspector
    public Transform shootingPoint; // Assign or create a point as child of player
    public float shootingRate = 5f; // Projectiles per second
    private float nextShootTime = 0f;

    public PlayerLevelManager playerLevelManager;

    void Update()
    {
        

        if (playerLevelManager != null) {
            shootingRate = 4f + PlayerLevelManager.Instance.currentLevel;
        }

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextShootTime)
        {
            ShootProjectile();
            nextShootTime = Time.time + 1f / shootingRate;
        }
    }

    void ShootProjectile()
    {
        // Instantiate the projectile at the shooting point
        // Adjust the rotation to match the trajectory and orientation
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        projectile.transform.Rotate(0, 0, -67.5f); // Adjust this rotation as needed
    }
}
