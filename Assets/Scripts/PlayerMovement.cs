using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerPosition1, PlayerPosition2, PlayerPosition3;
    private GameObject[] positions;
    private int currentPositionIndex;
    public float speed = 10f;

    void Start()
    {

        positions = new GameObject[] { PlayerPosition1, PlayerPosition2, PlayerPosition3 };
        currentPositionIndex = 1; 
    }
    void Update()
    {
        HandleMovementInput();
        MovePlayer();
    }

    void HandleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPositionIndex > 0)
        {
            currentPositionIndex--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPositionIndex < positions.Length - 1)
        {
            currentPositionIndex++;
        }
    }

    void MovePlayer()
    {
        transform.position = Vector3.Lerp(transform.position, positions[currentPositionIndex].transform.position, Time.deltaTime * speed);
    }
}
