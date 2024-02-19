using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameOver GameOverScreen;
    int maxHealth = 0;

    public void GameOver() 
    {
        GameOverScreen.SetUp(maxHealth);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
