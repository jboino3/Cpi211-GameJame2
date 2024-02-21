using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarrelHealthScript : MonoBehaviour
{
    public int health;
    public GameObject healthTextPrefab; // Assign in inspector
    private GameObject healthTextObject;
    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(GetMinHealth(), GetMaxHealth() + 1);

        healthTextObject = Instantiate(healthTextPrefab, FindAnyObjectByType<Canvas>().transform);
        healthText = healthTextObject.GetComponent<Text>();
        UpdateHealthText();
    }

    // Update is called once per frame
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
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1, 0));
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
            PlayerLevelManager.Instance.AddXP(1);
        }
    }

    int GetMinHealth(){return Mathf.FloorToInt(1 + Time.timeSinceLevelLoad / 30);}

    int GetMaxHealth() { return Mathf.FloorToInt(5 + Time.timeSinceLevelLoad / 15); }

}
