using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
   public int maxHealth = 4;
   public int currentHealth; 
   public Healthbar healthBar; 

   void Start()
   {
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
   }

   void Update() 
   {
   if (Input.GetKeyDown(KeyCode.Space))
   {
    TakeDamage(1);
   }
    
   }

   void TakeDamage(int damage)
   {
    currentHealth -= damage; 
    healthBar.SetHealth(currentHealth);
   }
}
