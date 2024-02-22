using UnityEngine;
using UnityEngine.UI;

public class BarrelHealthScript : MonoBehaviour
{
    public int health;
    public GameObject healthTextPrefab; // Assign in inspector
    private GameObject healthTextObject;
    private Text healthText;

    void Start()
    {
        // Generate a random health value and truncate it to the nearest threshold
        health = TruncateHealthToThreshold(Random.Range(GetMinHealth(), GetMaxHealth() + 1));

        healthTextObject = Instantiate(healthTextPrefab, FindAnyObjectByType<Canvas>().transform);
        healthText = healthTextObject.GetComponent<Text>();
        UpdateHealthText();
        UpdateHealthTextPosition();
    }

    void Update()
    {
        UpdateHealthTextPosition();
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    void UpdateHealthTextPosition()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0)); // Adjust Y offset as needed
        healthTextObject.transform.position = screenPosition;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthText();
        if (health <= 0)
        {
            Destroy(healthTextObject);
            Destroy(gameObject);
            PlayerLevelManager.Instance.AddXP(1); // Assuming you want to add XP here
        }
    }

    int GetMinHealth()
    {
        return Mathf.FloorToInt(5 + Time.timeSinceLevelLoad / 15);
    }

    int GetMaxHealth()
    { 
        return Mathf.FloorToInt(23 + Time.timeSinceLevelLoad / 10);
    }

    int TruncateHealthToThreshold(int healthValue)
    {
        int[] thresholds = { 5, 10, 15, 25, 50, 100 };
        for (int i = thresholds.Length - 1; i >= 0; i--)
        {
            if (healthValue >= thresholds[i])
            {
                return thresholds[i];
            }
        }
        return 5;
    }
}
