using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 10f;

    void Start(){Destroy(gameObject, 2f);}

    void Update()
    {
        //45-degree angle upwards
        Vector3 moveDirection = new Vector3(1, 0.5f, 0).normalized; 
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!other.CompareTag("Player")) 
        {

            if (other.gameObject.name.StartsWith("Barrel"))
            {
                

                BarrelHealthScript barrelHealth = other.GetComponent<BarrelHealthScript>();
                if (barrelHealth != null)
                {
                    Debug.Log("BARREL COLLISION!");
                    barrelHealth.TakeDamage(PlayerLevelManager.Instance.damage);
                }
            }

        }
    }

}
