using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelManager : MonoBehaviour
{
    public static PlayerLevelManager Instance { get; private set; }

    public int currentLevel = 1;
    public int currentXP = 0;
    public int xpTarget = 10; 
    public int damage = 1;

    public Text levelXPText;

    private void Start()
    {
        UpdateLevelXPDisplay();
    }

    private void UpdateLevelXPDisplay()
    {
        if (levelXPText != null) 
            levelXPText.text = $"Level: {currentLevel} | XP: {currentXP}/{xpTarget}";
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddXP(int xpToAdd)
    {
        currentXP += xpToAdd;
        if (currentXP >= xpTarget)
        {
            LevelUp();
        }
        UpdateLevelXPDisplay();
    }

    private void LevelUp()
    {
        currentLevel++;
        damage++;
        currentXP = 0; 
        xpTarget += currentLevel * 10;
        UpdateLevelXPDisplay();
    }

    public void ResetPlayer()
    {
        currentLevel = 1;
        currentXP = 0;
        xpTarget = 10;
        damage = 1;
    }
}
