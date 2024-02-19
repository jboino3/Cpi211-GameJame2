using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public Scoring score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            score.AddScore(1);
        }
    }
}
